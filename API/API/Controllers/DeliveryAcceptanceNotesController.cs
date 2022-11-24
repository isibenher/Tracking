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
    public class DeliveryAcceptanceNotesController : ControllerBase
    {
        private readonly APIContext _context;

        public DeliveryAcceptanceNotesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryAcceptanceNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryAcceptanceNote>>> GetDeliveryAcceptanceNote()
        {
            return await _context.DeliveryAcceptanceNote.ToListAsync();
        }

        // GET: api/DeliveryAcceptanceNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryAcceptanceNote>> GetDeliveryAcceptanceNote(int id)
        {
            var deliveryAcceptanceNote = await _context.DeliveryAcceptanceNote.FindAsync(id);

            if (deliveryAcceptanceNote == null)
            {
                return NotFound();
            }

            return deliveryAcceptanceNote;
        }

        // PUT: api/DeliveryAcceptanceNotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryAcceptanceNote(int id, DeliveryAcceptanceNote deliveryAcceptanceNote)
        {
            if (id != deliveryAcceptanceNote.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryAcceptanceNote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryAcceptanceNoteExists(id))
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

        // POST: api/DeliveryAcceptanceNotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryAcceptanceNote>> PostDeliveryAcceptanceNote(DeliveryAcceptanceNote deliveryAcceptanceNote)
        {
            _context.DeliveryAcceptanceNote.Add(deliveryAcceptanceNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryAcceptanceNote", new { id = deliveryAcceptanceNote.Id }, deliveryAcceptanceNote);
        }

        // DELETE: api/DeliveryAcceptanceNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryAcceptanceNote(int id)
        {
            var deliveryAcceptanceNote = await _context.DeliveryAcceptanceNote.FindAsync(id);
            if (deliveryAcceptanceNote == null)
            {
                return NotFound();
            }

            _context.DeliveryAcceptanceNote.Remove(deliveryAcceptanceNote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryAcceptanceNoteExists(int id)
        {
            return _context.DeliveryAcceptanceNote.Any(e => e.Id == id);
        }
    }
}
