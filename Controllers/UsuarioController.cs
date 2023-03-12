using APIAA.Models;
using APIAA.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace APIAA.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly VideojuegoContext _dbContext;

    public UsuariosController(VideojuegoContext dbContext)
    {
        _dbContext = dbContext;

    }



    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
    {
        if (_dbContext.Usuarios == null)
        {
            return NotFound();
        }
        return await _dbContext.Usuarios.OrderByDescending(i => i.Fecha).ToListAsync();

    }


    [HttpGet("(id)")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        if (_dbContext.Usuarios == null)
        {
            return NotFound();
        }

        var usuario = await _dbContext.Usuarios.FindAsync(id);

    if (usuario == null)
    {
        return NotFound();
    }
    return usuario;
}


    [HttpPost]

    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        _dbContext.Usuarios.Add(usuario);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        if (_dbContext.Usuarios == null)
        {
            return NotFound();
        }
        var usuario = await _dbContext.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }

        _dbContext.Usuarios.Remove(usuario);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
    {
        if (id != usuario.Id)
        {
            return BadRequest();
        }
        _dbContext.Entry(usuario).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(id))
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
    private bool UsuarioExists(long id)
    {
        return (_dbContext.Usuarios?.Any(u => u.Id == id)).GetValueOrDefault();
    }
}