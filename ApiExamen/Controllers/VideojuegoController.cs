using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiExamen.Data;
using ApiExamen.Model;

namespace ApiExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideojuegoController : Controller
    {
        private readonly VideojuegoContext _context;

        public VideojuegoController(VideojuegoContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videojuego>>> GetAlumnos()
        {
            return await _context.videojuegos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Videojuego>> GetAlumnoID(int id)
        {
            var alumnoid = await _context.videojuegos.FindAsync(id);
            return Ok(alumnoid);
        }

        [HttpPost]
        public async Task<ActionResult<Videojuego>> InsetarAlumno(Videojuego videojuego)

        {
            _context.videojuegos.Add(videojuego);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Videojuego>> EliminarAlumno(int id)
        {
            var alumnoelim = await _context.videojuegos.FindAsync(id);
            if (alumnoelim == null)
            {
                return NotFound();
            }
            _context.videojuegos.Remove(alumnoelim);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutAlumno(int id, Videojuego videojuego)
        {
            if (id != videojuego.ID)
            {
                return BadRequest();
            }

            _context.Entry(videojuego).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.videojuegos.Any(e => e.ID == id))
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
    }
}

