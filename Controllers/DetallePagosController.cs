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
    public class DetallePagosController : ControllerBase
    {
        private readonly Context _context;

        public DetallePagosController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePagos>>> GetDetallesAlumno()
        {
            return await _context.DetallesAlumno.Include(q => q.Alumno).Include(q => q.Mes).ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePagos>> GetDetallePagos([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detallePagos = await _context.DetallesAlumno.Include(q => q.Alumno).FirstOrDefaultAsync(q => q.idAlumno == id);
  
            if (detallePagos == null)
            {
                return NotFound();
            }

            return Ok(detallePagos);
        }
        
        [HttpGet]
        [Route("GetFecha/{fecha}")]
        public async Task<IActionResult> GetByFecha([FromRoute] DateTime fecha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pago_Alumno = await _context.DetallesAlumno.FirstOrDefaultAsync(f => f.fecha.Equals(fecha));

            return Ok(pago_Alumno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallePagos([FromRoute] long id, [FromBody] DetallePagos detallePagos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detallePagos.IdAlumno_master)
            {
                return BadRequest();
            }

            _context.Entry(detallePagos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePagosExists(id))
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

       
        [HttpPost]
        public async Task<ActionResult<DetallePagos>> PostDetallePagos([FromBody] DetallePagos detallePagos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DetallesAlumno.Add(detallePagos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallePagos", new { id = detallePagos.IdAlumno_master }, detallePagos);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePagos([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detallePagos = await _context.DetallesAlumno.FindAsync(id);
            if (detallePagos == null)
            {
                return NotFound();
            }

            _context.DetallesAlumno.Remove(detallePagos);
            await _context.SaveChangesAsync();

            return Ok(detallePagos);
        }

        private bool DetallePagosExists(long id)
        {
            return _context.DetallesAlumno.Any(e => e.IdAlumno_master == id);
        }
    }
}