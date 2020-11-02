using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SummerveldHoundResortAPIServer.Data;
using SummerveldHoundResortAPIServer.Models;

namespace SummerveldHoundResortAPIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoggoContentController : ControllerBase
    {
        private readonly DoggoDataContext _context;

        public DoggoContentController(DoggoDataContext context)
        {
            _context = context;
        }

        // GET: api/DoggoContent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoggoContent>>> GetdoggoContent()
        {
            return await _context.doggoContent.ToListAsync();
        }

        // GET: api/DoggoContent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoggoContent>> GetDoggoContent(int id)
        {
            var doggoContent = await _context.doggoContent.FindAsync(id);

            if (doggoContent == null)
            {
                return NotFound();
            }

            return doggoContent;
        }

        // PUT: api/DoggoContent/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoggoContent(int id, DoggoContent doggoContent)
        {
            if (id != doggoContent.DoggoContentId)
            {
                return BadRequest();
            }

            _context.Entry(doggoContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoggoContentExists(id))
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

        // POST: api/DoggoContent
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DoggoContent>> PostDoggoContent(DoggoContent doggoContent)
        {
            _context.doggoContent.Add(doggoContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoggoContent", new { id = doggoContent.DoggoContentId }, doggoContent);
        }

        // DELETE: api/DoggoContent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DoggoContent>> DeleteDoggoContent(int id)
        {
            var doggoContent = await _context.doggoContent.FindAsync(id);
            if (doggoContent == null)
            {
                return NotFound();
            }

            _context.doggoContent.Remove(doggoContent);
            await _context.SaveChangesAsync();

            return doggoContent;
        }

        private bool DoggoContentExists(int id)
        {
            return _context.doggoContent.Any(e => e.DoggoContentId == id);
        }
    }
}
