using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class PresupuestosController : ControllerBase
{
    private readonly IPresupuestosRepository _presupuestosRepository;
    private readonly IProductoRepository _productoRepository;

    public PresupuestosController(IPresupuestosRepository presupuestosRepository, IProductoRepository productoRepository)
    {
        _presupuestosRepository = presupuestosRepository;
        _productoRepository = productoRepository;
    }

    [HttpPost]
    public IActionResult CreatePresupuesto([FromBody] Presupuesto presupuesto)
    {
        if (presupuesto == null)
            return BadRequest("El presupuesto es nulo.");

        _presupuestosRepository.Insert(presupuesto);
        return CreatedAtAction(nameof(GetPresupuestos), new { id = presupuesto.IdPresupuesto }, presupuesto);
    }

    [HttpPost("{id}/ProductoDetalle")]
    public IActionResult AddProductoToPresupuesto(int id, [FromBody] PresupuestoDetalle detalle)
    {
        var presupuesto = _presupuestosRepository.FindById(id);
        if (presupuesto == null)
            return NotFound("Presupuesto no encontrado.");

        var producto = _productoRepository.FindById(detalle.Producto.IdProducto);
        if (producto == null)
            return NotFound("Producto no encontrado.");

        detalle.Producto = producto;
        presupuesto.Detalle.Add(detalle);
        return Ok(presupuesto);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Presupuesto>> GetPresupuestos()
    {
        var presupuestos = _presupuestosRepository.FindAll();
        return Ok(presupuestos);
    }
}
