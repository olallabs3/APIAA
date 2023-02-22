using APIAA.Models;
using APIAA.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIAA.Controllers;

[ApiController]
[Route("[controller]")]
public class VideojuegoController : ControllerBase
{
    public VideojuegoController()
    {
    }

    [HttpGet]
    public ActionResult<List<Videojuego>> GetAll() =>
    VideojuegoService.GetAll();

    [HttpGet("Videojuego/agotado")]
    public ActionResult<List<Videojuego>> GetNotAgotados() =>
    VideojuegoService.GetNotAgotados();

    [HttpGet("{id}")]
    /*Esto creo que es cosa de Alex*/
    public ActionResult<Videojuego> Get(int id , [FromQuery] int idVideojuego, string titulo, Boolean agotado = false)
    {
        var videojuego = VideojuegoService.Get(id);

        if (videojuego == null)
            return NotFound();

        return videojuego;
    }
    /*Igual se puede combinar con el HttpGet anterior*/
    [HttpGet("{id}/Transacciones")]
    public ActionResult<List<Transaccion>> Get(int id){
        List<Transaccion> registros = TransaccionService.GetAll().Where(x => x.VideojuegoId == id).ToList();

        if(registros == null){
            return NotFound();
        }
        
        return registros;
    }


    [HttpPost]
    public IActionResult Create([FromBody]Videojuego videojuego)
    {
        VideojuegoService.Add(videojuego);
        return CreatedAtAction(nameof(Get), new { id = videojuego.Id }, videojuego);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Videojuego videojuego)
    {
        if (id != videojuego.Id)
            return BadRequest();

        var existingVideojuego = VideojuegoService.Get(id);
        if (existingVideojuego is null)
            return NotFound();

        VideojuegoService.Update(videojuego);

        return NoContent();
        
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var videojuego = VideojuegoService.Get(id);

        if (videojuego is null)
            return NotFound();

        VideojuegoService.Delete(id);

        return NoContent();
    }
}