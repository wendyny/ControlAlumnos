using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlAlumnos.Models;

namespace ControlAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradosController : ControllerBase
    {
        private readonly Context _context;

        public GradosController(Context context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grado>>> GetGrados()
        {
            return await _context.Grados.Include(g => g.alumnos).ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrado([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grado = await _context.Grados.FindAsync(id);

            if (grado == null)
            {
                return NotFound();
            }

            return Ok(grado);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrado([FromRoute] int id, [FromBody] Grado grado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grado.idGrado)
            {
                return BadRequest();
            }

            _context.Entry(grado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
             if (!GradoExists(id))
                {
                    return NotFound();
                }
                

            return NoContent();
        }

       
        [HttpPost]
        public async Task<IActionResult> PostGrado([FromBody] Grado grado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Grados.Add(grado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrado", new { id = grado.idGrado }, grado);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrado([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grado = await _context.Grados.FindAsync(id);
            if (grado == null)
            {
                return NotFound();
            }

            _context.Grados.Remove(grado);
            await _context.SaveChangesAsync();

            return Ok(grado);
        }

        private bool GradoExists(int id)
        {
            return _context.Grados.Any(e => e.idGrado == id);
        }
    }
}