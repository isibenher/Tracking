using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiglumsController : ControllerBase
    {
        private readonly APIContext _context;

        public SiglumsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Siglums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Siglum>>> GetSiglum()
        {
            return await _context.Siglum.ToListAsync();
        }

        // GET: api/Siglums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Siglum>> GetSiglum(int id)
        {
            var siglum = await _context.Siglum.FindAsync(id);

            if (siglum == null)
            {
                return NotFound();
            }

            return siglum;
        }

        // PUT: api/Siglums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSiglum(int id, Siglum siglum)
        {
            if (id != siglum.Id)
            {
                return BadRequest();
            }

            _context.Entry(siglum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiglumExists(id))
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

        // POST: api/Siglums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Siglum>> PostSiglum(Siglum siglum)
        {
            _context.Siglum.Add(siglum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSiglum", new { id = siglum.Id }, siglum);
        }

        // DELETE: api/Siglums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSiglum(int id)
        {
            var siglum = await _context.Siglum.FindAsync(id);
            if (siglum == null)
            {
                return NotFound();
            }

            _context.Siglum.Remove(siglum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SiglumExists(int id)
        {
            return _context.Siglum.Any(e => e.Id == id);
        }
    }
}
