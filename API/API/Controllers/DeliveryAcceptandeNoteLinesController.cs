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
    public class DeliveryAcceptandeNoteLinesController : ControllerBase
    {
        private readonly APIContext _context;

        public DeliveryAcceptandeNoteLinesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryAcceptandeNoteLines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryAcceptandeNoteLine>>> GetDeliveryAcceptandeNoteLine()
        {
            return await _context.DeliveryAcceptandeNoteLine.ToListAsync();
        }

        // GET: api/DeliveryAcceptandeNoteLines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryAcceptandeNoteLine>> GetDeliveryAcceptandeNoteLine(int id)
        {
            var deliveryAcceptandeNoteLine = await _context.DeliveryAcceptandeNoteLine.FindAsync(id);

            if (deliveryAcceptandeNoteLine == null)
            {
                return NotFound();
            }

            return deliveryAcceptandeNoteLine;
        }

        // PUT: api/DeliveryAcceptandeNoteLines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryAcceptandeNoteLine(int id, DeliveryAcceptandeNoteLine deliveryAcceptandeNoteLine)
        {
            if (id != deliveryAcceptandeNoteLine.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryAcceptandeNoteLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryAcceptandeNoteLineExists(id))
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

        // POST: api/DeliveryAcceptandeNoteLines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryAcceptandeNoteLine>> PostDeliveryAcceptandeNoteLine(DeliveryAcceptandeNoteLine deliveryAcceptandeNoteLine)
        {
            _context.DeliveryAcceptandeNoteLine.Add(deliveryAcceptandeNoteLine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryAcceptandeNoteLine", new { id = deliveryAcceptandeNoteLine.Id }, deliveryAcceptandeNoteLine);
        }

        // DELETE: api/DeliveryAcceptandeNoteLines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryAcceptandeNoteLine(int id)
        {
            var deliveryAcceptandeNoteLine = await _context.DeliveryAcceptandeNoteLine.FindAsync(id);
            if (deliveryAcceptandeNoteLine == null)
            {
                return NotFound();
            }

            _context.DeliveryAcceptandeNoteLine.Remove(deliveryAcceptandeNoteLine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryAcceptandeNoteLineExists(int id)
        {
            return _context.DeliveryAcceptandeNoteLine.Any(e => e.Id == id);
        }
    }
}
