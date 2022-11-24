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
    public class ProjectSubcontratorsController : ControllerBase
    {
        private readonly APIContext _context;

        public ProjectSubcontratorsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/ProjectSubcontrators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectSubcontrator>>> GetProjectSubcontrator()
        {
            return await _context.ProjectSubcontrator.ToListAsync();
        }

        // GET: api/ProjectSubcontrators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectSubcontrator>> GetProjectSubcontrator(int id)
        {
            var projectSubcontrator = await _context.ProjectSubcontrator.FindAsync(id);

            if (projectSubcontrator == null)
            {
                return NotFound();
            }

            return projectSubcontrator;
        }

        // PUT: api/ProjectSubcontrators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectSubcontrator(int id, ProjectSubcontrator projectSubcontrator)
        {
            if (id != projectSubcontrator.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectSubcontrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectSubcontratorExists(id))
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

        // POST: api/ProjectSubcontrators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectSubcontrator>> PostProjectSubcontrator(ProjectSubcontrator projectSubcontrator)
        {
            _context.ProjectSubcontrator.Add(projectSubcontrator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectSubcontrator", new { id = projectSubcontrator.Id }, projectSubcontrator);
        }

        // DELETE: api/ProjectSubcontrators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectSubcontrator(int id)
        {
            var projectSubcontrator = await _context.ProjectSubcontrator.FindAsync(id);
            if (projectSubcontrator == null)
            {
                return NotFound();
            }

            _context.ProjectSubcontrator.Remove(projectSubcontrator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectSubcontratorExists(int id)
        {
            return _context.ProjectSubcontrator.Any(e => e.Id == id);
        }
    }
}
