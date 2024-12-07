using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Models;

[Route("api/[controller]")]
[ApiController]
public class ConductoresController : ControllerBase
{
    private readonly TaxiContexto _context;

    public ConductoresController(TaxiContexto context)
    {
        _context = context;
    }

    // GET: api/Conductores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Conductor>>> GetConductores()
    {
        return await _context.Conductores.ToListAsync();
    }

    // GET: api/Conductores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Conductor>> GetConductor(int id)
    {
        var conductor = await _context.Conductores.FindAsync(id);

        if (conductor == null)
        {
            return NotFound();
        }

        return conductor;
    }

    // POST: api/Conductores
    [HttpPost]
    public async Task<ActionResult<Conductor>> PostConductor(Conductor conductor)
    {
        _context.Conductores.Add(conductor);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetConductor", new { id = conductor.Id }, conductor);
    }

    // PUT: api/Conductores/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutConductor(int id, Conductor conductor)
    {
        if (id != conductor.Id)
        {
            return BadRequest();
        }

        _context.Entry(conductor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ConductorExists(id))
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

    // DELETE: api/Conductores/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConductor(int id)
    {
        var conductor = await _context.Conductores.FindAsync(id);
        if (conductor == null)
        {
            return NotFound();
        }

        _context.Conductores.Remove(conductor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ConductorExists(int id)
    {
        return _context.Conductores.Any(e => e.Id == id);
    }
}
