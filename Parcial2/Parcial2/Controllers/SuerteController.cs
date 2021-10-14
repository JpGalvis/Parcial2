using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial2.Data;
using Parcial2.Models;

namespace Parcial2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuerteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SuerteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Suerte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suerte>>> GetSuertes()
        {
            return await _context.Suertes.ToListAsync();
        }

        // GET: api/Suerte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suerte>> GetSuerte(string id)
        {
            var suerte = await _context.Suertes.FindAsync(id);

            if (suerte == null)
            {
                return NotFound();
            }

            return suerte;
        }

        // PUT: api/Suerte/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuerte(string id, Suerte suerte)
        {
            if (id != suerte.futuro)
            {
                return BadRequest();
            }

            _context.Entry(suerte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuerteExists(id))
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

        // POST: api/Suerte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Suerte>> PostSuerte(Suerte suerte)
        {
            _context.Suertes.Add(suerte);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SuerteExists(suerte.futuro))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSuerte", new { id = suerte.futuro }, suerte);
        }

        // DELETE: api/Suerte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuerte(string id)
        {
            var suerte = await _context.Suertes.FindAsync(id);
            if (suerte == null)
            {
                return NotFound();
            }

            _context.Suertes.Remove(suerte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuerteExists(string id)
        {
            return _context.Suertes.Any(e => e.futuro == id);
        }
    }
}
