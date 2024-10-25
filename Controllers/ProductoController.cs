using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : ControllerBase
{
    private readonly IProductoRepository _productoRepository;

    public ProductoController(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    [HttpPost]
    public IActionResult CreateProducto([FromBody] Producto producto)
    {
        if (producto == null)
            return BadRequest("El producto es nulo.");

        _productoRepository.Insert(producto);
        return CreatedAtAction(nameof(GetProductoById), new { id = producto.IdProducto }, producto);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Producto>> GetProductos()
    {
        var productos = _productoRepository.FindAll();
        return Ok(productos);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProducto(int id, [FromBody] string descripcion)
    {
        var producto = _productoRepository.FindById(id);
        if (producto == null)
            return NotFound("Producto no encontrado.");

        producto.Descripcion = descripcion;
        _productoRepository.Update(id, producto);
        return NoContent();
    }
}
