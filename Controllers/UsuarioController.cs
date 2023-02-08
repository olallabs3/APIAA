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
    return await _dbContext.Usuarios.ToListAsync();
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

public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario){
    _dbContext.Usuarios.Add(usuario);
    await _dbContext.SaveChangesAsync();

    return CreatedAtAction(nameof(GetUsuario), new {id = usuario.Id}, usuario);
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


    //NO LLEGA A IR
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


// [ApiController]
// [Route("[controller]")]
// public class UsuarioController : ControllerBase
// {
//     public UsuarioController()
//     {
//     }

//     [HttpGet]
//     public ActionResult<List<Usuario>> GetAll() =>
//     UsuarioService.GetAll();

//     [HttpGet("{id}")]
//     public ActionResult<Usuario> Get(int id)
//     {
//         var GetUsuario = UsuarioService.Get(id);

//         if (GetUsuario == null)
//             return NotFound();

//         return GetUsuario;
//     }

//     [HttpGet("/{nombre}")]
//     public ActionResult<Usuario> GetNombre(string nombre)
//     {
//         var GetUsuario = UsuarioService.GetNombre(nombre);

//         if (GetUsuario == null)
//             return NotFound();

//         return GetUsuario;
//     }


//     [HttpPost]
//     public IActionResult Create(Usuario GetUsuario)
//     {
//         UsuarioService.Add(GetUsuario);
//         return CreatedAtAction(nameof(Get), new { id = GetUsuario.Id }, GetUsuario);
//     }

//     [HttpPut("{id}")]
//     public IActionResult Update(int id, Usuario GetUsuario)
//     {
//         if (id != GetUsuario.Id)
//             return BadRequest();

//         var existingUsuario = UsuarioService.Get(id);
//         if (existingUsuario is null)
//             return NotFound();

//         UsuarioService.Update(GetUsuario);

//         return NoContent();
//     }

//     Borrado por id 
//     [HttpDelete("{id}")]
//     public IActionResult Delete(int id)
//     {
//         var GetUsuario = UsuarioService.Get(id);

//         if (GetUsuario is null)
//             return NotFound();

//         UsuarioService.Delete(id);

//         return NoContent();
//     }

//     //Borrado por nombre 
//     [HttpDelete("/{nombre}")]
//     public IActionResult Delete(string nombre)
//     {
//         var GetUsuario = UsuarioService.GetNombre(nombre);

//         if (GetUsuario is null)
//             return NotFound();

//         UsuarioService.Delete(nombre);

//         return NoContent();
//     }
// }