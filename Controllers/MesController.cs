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
    public class MesController : ControllerBase
    {
        private readonly Context _context;

        public MesController(Context context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IEnumerable<Mes> GetMeses()
        {
            return _context.Meses;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMes([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mes = await _context.Meses.FindAsync(id);

            if (mes == null)
            {
                return NotFound();
            }

            return Ok(mes);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMes([FromRoute] long id, [FromBody] Mes mes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mes.idMes)
            {
                return BadRequest();
            }

            _context.Entry(mes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
           
                if (!MesExists(id))
                {
                    return NotFound();
                }
                

            return NoContent();
        }

       
        [HttpPost]
        public async Task<IActionResult> PostMes([FromBody] Mes mes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Meses.Add(mes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMes", new { id = mes.idMes }, mes);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMes([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mes = await _context.Meses.FindAsync(id);
            if (mes == null)
            {
                return NotFound();
            }

            _context.Meses.Remove(mes);
            await _context.SaveChangesAsync();

            return Ok(mes);
        }

        private bool MesExists(long id)
        {
            return _context.Meses.Any(e => e.idMes == id);
        }
    }
}