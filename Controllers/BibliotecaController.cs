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

    [HttpGet("(id)")]
    public async Task<ActionResult<List<Biblioteca>>> GetBiblioteca(int id)
    {
        if (_context.Bibliotecas == null)
        {
            return NotFound();
        }

        var bibliotecas = await _context.Bibliotecas.Where(b => b.UsuarioId == id).ToListAsync();

        if (bibliotecas == null)
        {
            return NotFound();
        }
        return bibliotecas;
    }

    [HttpPost("agregarVideojuego")]
    public async Task<ActionResult<Biblioteca>> AgregarVideojuego([FromBody] Biblioteca biblioteca)
    {
        _context.Bibliotecas.Add(biblioteca);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBiblioteca", new { id = biblioteca.UsuarioId, videojuegoId = biblioteca.VideojuegoId });
    }


}
