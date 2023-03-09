using APIAA.Models;
using APIAA.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIAA.Controllers;

[ApiController]
[Route("[controller]")]

public class BibliotecaController : ControllerBase
{
    private readonly VideojuegoContext _context;

    public BibliotecaController(VideojuegoContext context)
    {
        _context = context;
    }

    /*Añadir un videojuego a un usuario*/
    /* [HttpPost("{idUsuario}/Videojuegos")]
    public IActionResult AddVideojuego(int idUsuario, [FromBody] Videojuego videojuego)
    {
        var usuario = _context.Usuarios.Include(u => u.Bibliotecas).SingleOrDefault(u => u.Id == idUsuario);

        if (usuario == null)
        {
            return NotFound();
        }

        var biblioteca = new Biblioteca
        {
            UsuarioId = usuario.Id,
            VideojuegoId = videojuego.Id
        };

        usuario.Bibliotecas.Add(biblioteca);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = biblioteca.Id }, biblioteca);
    } */

    [HttpPost("agregarVideojuego")]
    public async Task<ActionResult<Biblioteca>> AgregarVideojuego([FromBody] Biblioteca biblioteca)
    {
        _context.Bibliotecas.Add(biblioteca);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBiblioteca", new { id = biblioteca.UsuarioId, videojuegoId = biblioteca.VideojuegoId }, biblioteca);
    }


}
