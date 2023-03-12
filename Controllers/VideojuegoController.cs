using APIAA.Models;
using APIAA.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace APIAA.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideojuegoController : ControllerBase
{
    private readonly VideojuegoContext _dbContext;

    public VideojuegoController(VideojuegoContext dbContext)
    {
        _dbContext = dbContext;
    }


    // GET ALL VIDEOJUEGOS
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Videojuego>>> GetUsuario()
    {
        if (_dbContext.Videojuegos == null)
        {
            return NotFound();
        }
        return await _dbContext.Videojuegos.OrderByDescending(i => i.Unidades).ToListAsync();
    }

  [HttpGet("(id)")]
    public async Task<ActionResult<Videojuego>> GetVideojuego(int id)
    {
        if (_dbContext.Videojuegos == null)
        {
            return NotFound();
        }

        var videojuego = await _dbContext.Videojuegos.FindAsync(id);

        if (videojuego == null)
        {
            return NotFound();
        }
        return videojuego;
    }

    //CREAR NUEVO JUEGO
    [HttpPost]
    public async Task<ActionResult<Videojuego>> PostVideojuego(Videojuego videojuego)
    {
        _dbContext.Videojuegos.Add(videojuego);
        await _dbContext.SaveChangesAsync();

        return videojuego;
    }

   

    //ACTUALIZAR UN JUEGO
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVideojuego(int id, Videojuego videojuego)
    {
        if (id != videojuego.Id)
        {
            return BadRequest();
        }
        _dbContext.Entry(videojuego).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VideojuegoExists(id))
            {
                return NotFound();

            }
            else
            {
                throw;
            }

        }
        return NoContent();
        
    }
    private bool VideojuegoExists(long id)
    {
        return (_dbContext.Videojuegos?.Any(v => v.Id == id)).GetValueOrDefault();
    }


      //BORRADO DE VIDEOJUEGO POR ID

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVideojuego(int id)
    {
        if (_dbContext.Videojuegos == null)
        {
            return NotFound();
        }

        var videojuego = await _dbContext.Videojuegos.FindAsync(id);
        if (videojuego == null)
        {
            return NotFound();
        }
        _dbContext.Videojuegos.Remove(videojuego);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}