using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ViajesController : ControllerBase
{
    private readonly TaxiContexto _context;

    public ViajesController(TaxiContexto context)
    {
        _context = context;
    }

    // GET: api/Viajes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Viaje>>> GetViajes()
    {
        return await _context.Viajes.ToListAsync();
    }

    // GET: api/Viajes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Viaje>> GetViaje(int id)
    {
        var viaje = await _context.Viajes.FindAsync(id);

        if (viaje == null)
        {
            return NotFound();
        }

        return viaje;
    }

    // POST: api/Viajes
    [HttpPost]
    public async Task<ActionResult<Viaje>> PostViaje(Viaje viaje)
    {
        _context.Viajes.Add(viaje);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetViaje", new { id = viaje.Id }, viaje);
    }

    // PUT: api/Viajes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutViaje(int id, Viaje viaje)
    {
        if (id != viaje.Id)
        {
            return BadRequest();
        }

        _context.Entry(viaje).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ViajeExists(id))
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

    // DELETE: api/Viajes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteViaje(int id)
    {
        var viaje = await _context.Viajes.FindAsync(id);
        if (viaje == null)
        {
            return NotFound();
        }

        _context.Viajes.Remove(viaje);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ViajeExists(int id)
    {
        return _context.Viajes.Any(e => e.Id == id);
    }
}