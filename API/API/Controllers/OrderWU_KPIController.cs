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
    public class OrderWU_KPIController : ControllerBase
    {
        private readonly APIContext _context;

        public OrderWU_KPIController(APIContext context)
        {
            _context = context;
        }

        // GET: api/OrderWU_KPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderWU_KPI>>> GetOrderWU_KPI()
        {
            return await _context.OrderWU_KPI.ToListAsync();
        }

        // GET: api/OrderWU_KPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderWU_KPI>> GetOrderWU_KPI(int id)
        {
            var orderWU_KPI = await _context.OrderWU_KPI.FindAsync(id);

            if (orderWU_KPI == null)
            {
                return NotFound();
            }

            return orderWU_KPI;
        }

        // PUT: api/OrderWU_KPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderWU_KPI(int id, OrderWU_KPI orderWU_KPI)
        {
            if (id != orderWU_KPI.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderWU_KPI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderWU_KPIExists(id))
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

        // POST: api/OrderWU_KPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderWU_KPI>> PostOrderWU_KPI(OrderWU_KPI orderWU_KPI)
        {
            _context.OrderWU_KPI.Add(orderWU_KPI);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderWU_KPI", new { id = orderWU_KPI.Id }, orderWU_KPI);
        }

        // DELETE: api/OrderWU_KPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderWU_KPI(int id)
        {
            var orderWU_KPI = await _context.OrderWU_KPI.FindAsync(id);
            if (orderWU_KPI == null)
            {
                return NotFound();
            }

            _context.OrderWU_KPI.Remove(orderWU_KPI);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderWU_KPIExists(int id)
        {
            return _context.OrderWU_KPI.Any(e => e.Id == id);
        }
    }
}
