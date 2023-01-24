using APIfutfem.Models;
using APIfutfem.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIfutfem.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    public UsuarioController()
    {
    }

    [HttpGet]
    public ActionResult<List<Usuario>> GetAll() =>
    UsuarioService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Usuario> Get(int id)
    {
        var usuario = UsuarioService.Get(id);

        if (usuario == null)
            return NotFound();

        return usuario;
    }

    [HttpPost]
    public IActionResult Create(Usuario usuario)
    {
        UsuarioService.Add(usuario);
        return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Usuario usuario)
    {
        if (id != usuario.Id)
            return BadRequest();

        var existingUsuario = UsuarioService.Get(id);
        if (existingUsuario is null)
            return NotFound();

        UsuarioService.Update(usuario);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var usuario = UsuarioService.Get(id);

        if (usuario is null)
            return NotFound();

        UsuarioService.Delete(id);

        return NoContent();
    }
}