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
    public ActionResult<Videojuego> Get(int id)
    {
        var videojuego = VideojuegoService.Get(id);

        if (videojuego == null)
            return NotFound();

        return videojuego;
    }

    [HttpPost]
    public IActionResult Create(Videojuego videojuego)
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