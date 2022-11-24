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
    public class OrderWUDistributionsController : ControllerBase
    {
        private readonly APIContext _context;

        public OrderWUDistributionsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/OrderWUDistributions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderWUDistribution>>> GetOrderWUDistribution()
        {
            return await _context.OrderWUDistribution.ToListAsync();
        }

        // GET: api/OrderWUDistributions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderWUDistribution>> GetOrderWUDistribution(int id)
        {
            var orderWUDistribution = await _context.OrderWUDistribution.FindAsync(id);

            if (orderWUDistribution == null)
            {
                return NotFound();
            }

            return orderWUDistribution;
        }

        // PUT: api/OrderWUDistributions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderWUDistribution(int id, OrderWUDistribution orderWUDistribution)
        {
            if (id != orderWUDistribution.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderWUDistribution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderWUDistributionExists(id))
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

        // POST: api/OrderWUDistributions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderWUDistribution>> PostOrderWUDistribution(OrderWUDistribution orderWUDistribution)
        {
            _context.OrderWUDistribution.Add(orderWUDistribution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderWUDistribution", new { id = orderWUDistribution.Id }, orderWUDistribution);
        }

        // DELETE: api/OrderWUDistributions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderWUDistribution(int id)
        {
            var orderWUDistribution = await _context.OrderWUDistribution.FindAsync(id);
            if (orderWUDistribution == null)
            {
                return NotFound();
            }

            _context.OrderWUDistribution.Remove(orderWUDistribution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderWUDistributionExists(int id)
        {
            return _context.OrderWUDistribution.Any(e => e.Id == id);
        }
    }
}
