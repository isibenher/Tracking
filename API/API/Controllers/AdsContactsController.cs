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
    public class AdsContactsController : ControllerBase
    {
        private readonly APIContext _context;

        public AdsContactsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/AdsContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdsContact>>> GetAdsContact()
        {
            return await _context.AdsContact.ToListAsync();
        }

        // GET: api/AdsContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdsContact>> GetAdsContact(int id)
        {
            var adsContact = await _context.AdsContact.FindAsync(id);

            if (adsContact == null)
            {
                return NotFound();
            }

            return adsContact;
        }

        // PUT: api/AdsContacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdsContact(int id, AdsContact adsContact)
        {
            if (id != adsContact.Id)
            {
                return BadRequest();
            }

            _context.Entry(adsContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdsContactExists(id))
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

        // POST: api/AdsContacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdsContact>> PostAdsContact(AdsContact adsContact)
        {
            _context.AdsContact.Add(adsContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdsContact", new { id = adsContact.Id }, adsContact);
        }

        // DELETE: api/AdsContacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdsContact(int id)
        {
            var adsContact = await _context.AdsContact.FindAsync(id);
            if (adsContact == null)
            {
                return NotFound();
            }

            _context.AdsContact.Remove(adsContact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdsContactExists(int id)
        {
            return _context.AdsContact.Any(e => e.Id == id);
        }
    }
}
