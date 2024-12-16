using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class PresupuestosController : ControllerBase
{
    private readonly ILogger<PresupuestosController> _logger;
    private PresupuestosRepository repositorioPresupuestos;
    public PresupuestosController(ILogger<PresupuestosController> logger){
        _logger=logger;
        repositorioPresupuestos = new PresupuestosRepository();
    }

    [HttpPost("api/Presupuesto")]
    public IActionResult CrearPresupuesto(Presupuestos presupuesto){
        repositorioPresupuestos.CrearPresupuesto(presupuesto);
        return Created("Repositorio creado correctamente", presupuesto);
    }

    [HttpPost("api/Presupuesto/{id}/ProductoDetalle")]
    public IActionResult AgregarProductoAPresupuesto(int idPresupuesto, int idProducto, int cantidad){
        repositorioPresupuestos.AgregarProducto(idPresupuesto, idProducto, cantidad);
        return Created("Producto agregado con exito", 1);
    }

    [HttpGet("api/Presupuestos")]
    public ActionResult<List<Presupuestos>> ObtenerPresupuestos(){
        return Ok(repositorioPresupuestos.ListarPresupuestosGuardados());
    }
    [HttpGet("api/Presupuestos/{id}")]
    public ActionResult<Presupuestos> ObtenerPresupuestoPorId(int id){
        return Ok(repositorioPresupuestos.ObtenerPresupuestoPorId(id));
    }
    [HttpDelete("api/Presupuestos/{id}")]
    public IActionResult EliminarPresupuestoPorId(int id){
        repositorioPresupuestos.EliminarPresupuestoPorId(id);
        return Ok();
    }
}
