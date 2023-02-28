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
        return await _dbContext.Videojuegos.ToListAsync();
    }

   
    //Boolean parametro de entrada

    [HttpGet("Videojuegos/agotado")]
    public async Task<ActionResult<IEnumerable<Videojuego>>> GetNotAgotados()
     => VideojuegoService.GetNotAgotados();

  

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


    // [HttpGet("{id}")]
    // /*Esto creo que es cosa de Alex*/
    // public ActionResult<Videojuego> Get(int id, [FromQuery] int idVideojuego, string titulo, Boolean agotado = false)
    // {
    //     var videojuego = VideojuegoService.Get(id);

    //     if (videojuego == null)
    //         return NotFound();

    //     return videojuego;
    // }
    /*Igual se puede combinar con el HttpGet anterior*/
    [HttpGet("{id}/Transacciones")]
    public ActionResult<List<Transaccion>> Get(int id)
    {
        List<Transaccion> registros = TransaccionService.GetAll().Where(x => x.VideojuegoId == id).ToList();

        if (registros == null)
        {
            return NotFound();
        }

        return registros;
    }


    //CREAR NUEVO JUEGO
    [HttpPost]
    public async Task<ActionResult<Videojuego>> PostVideojuego(Videojuego videojuego)
    {
        _dbContext.Videojuegos.Add(videojuego);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = videojuego.Id }, videojuego);
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


  // [HttpGet("Videojuegos/agotado")]
    // public ActionResult<List<Videojuegos>> GetNotAgotados() =>
    // VideojuegoService.GetNotAgotados();

 // [HttpPost]
    // public IActionResult Create([FromBody]Videojuegos videojuego)
    // {
    //     VideojuegoService.Add(videojuego);
    //     return CreatedAtAction(nameof(Get), new { id = videojuego.Id }, videojuego);
    // }

 // [HttpPut("{id}")]
    // public IActionResult Update(int id, Videojuegos videojuego)
    // {
    //     if (id != videojuego.Id)
    //         return BadRequest();

    //     var existingVideojuego = VideojuegoService.Get(id);
    //     if (existingVideojuego is null)
    //         return NotFound();

    //     VideojuegoService.Update(videojuego);

    //     return NoContent();
    // }


 // [HttpGet]
    // public ActionResult<List<Videojuegos>> GetAll() =>
    // VideojuegoService.GetAll();


   // [HttpDelete("{id}")]
    // public IActionResult Delete(int id)
    // {
    //     var videojuego = VideojuegoService.Get(id);

    //     if (videojuego is null)
    //         return NotFound();

    //     VideojuegoService.Delete(id);

    //     return NoContent();
    // }