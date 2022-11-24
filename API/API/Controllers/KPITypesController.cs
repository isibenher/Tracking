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
    public class KPITypesController : ControllerBase
    {
        private readonly APIContext _context;

        public KPITypesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/KPITypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KPIType>>> GetKPIType()
        {
            return await _context.KPIType.ToListAsync();
        }

        // GET: api/KPITypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KPIType>> GetKPIType(int id)
        {
            var kPIType = await _context.KPIType.FindAsync(id);

            if (kPIType == null)
            {
                return NotFound();
            }

            return kPIType;
        }

        // PUT: api/KPITypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKPIType(int id, KPIType kPIType)
        {
            if (id != kPIType.Id)
            {
                return BadRequest();
            }

            _context.Entry(kPIType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KPITypeExists(id))
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

        // POST: api/KPITypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KPIType>> PostKPIType(KPIType kPIType)
        {
            _context.KPIType.Add(kPIType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKPIType", new { id = kPIType.Id }, kPIType);
        }

        // DELETE: api/KPITypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKPIType(int id)
        {
            var kPIType = await _context.KPIType.FindAsync(id);
            if (kPIType == null)
            {
                return NotFound();
            }

            _context.KPIType.Remove(kPIType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KPITypeExists(int id)
        {
            return _context.KPIType.Any(e => e.Id == id);
        }
    }
}
