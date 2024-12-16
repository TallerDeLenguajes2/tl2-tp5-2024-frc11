using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase{
    private readonly ILogger<ProductosController> _logger;
    private ProductosRepository repositorioProductos;
    public ProductosController(ILogger<ProductosController> logger){
        _logger=logger;
        repositorioProductos=new ProductosRepository();
    }
    [HttpPost("api/Producto")]
    public IActionResult CrearProducto(Productos producto){
        repositorioProductos.CrearNuevoProducto(producto);
        return Created("Producto creado con exito", producto);
    }

    [HttpGet("api/Productos")]
    public ActionResult<List<Productos>> ObtenerProductos(){
        return Ok(repositorioProductos.ListarProductosRegistrados());
    }

    [HttpPut("api/Productos/{id}")]
    public IActionResult ModificarProducto(int id, Productos producto){
        repositorioProductos.ModificarProducto(id, producto);
        return Ok();
    }
}
