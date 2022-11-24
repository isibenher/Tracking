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
    public class OrderWUForecastsController : ControllerBase
    {
        private readonly APIContext _context;

        public OrderWUForecastsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/OrderWUForecasts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderWUForecast>>> GetOrderWUForecast()
        {
            return await _context.OrderWUForecast.ToListAsync();
        }

        // GET: api/OrderWUForecasts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderWUForecast>> GetOrderWUForecast(int id)
        {
            var orderWUForecast = await _context.OrderWUForecast.FindAsync(id);

            if (orderWUForecast == null)
            {
                return NotFound();
            }

            return orderWUForecast;
        }

        // PUT: api/OrderWUForecasts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderWUForecast(int id, OrderWUForecast orderWUForecast)
        {
            if (id != orderWUForecast.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderWUForecast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderWUForecastExists(id))
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

        // POST: api/OrderWUForecasts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderWUForecast>> PostOrderWUForecast(OrderWUForecast orderWUForecast)
        {
            _context.OrderWUForecast.Add(orderWUForecast);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderWUForecast", new { id = orderWUForecast.Id }, orderWUForecast);
        }

        // DELETE: api/OrderWUForecasts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderWUForecast(int id)
        {
            var orderWUForecast = await _context.OrderWUForecast.FindAsync(id);
            if (orderWUForecast == null)
            {
                return NotFound();
            }

            _context.OrderWUForecast.Remove(orderWUForecast);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderWUForecastExists(int id)
        {
            return _context.OrderWUForecast.Any(e => e.Id == id);
        }
    }
}
