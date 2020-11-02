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
    public class AdoptedController : ControllerBase
    {
        private readonly DoggoDataContext _context;

        public AdoptedController(DoggoDataContext context)
        {
            _context = context;
        }

        // GET: api/Adopted
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adopted>>> Getadopted()
        {
            return await _context.adopted.ToListAsync();
        }

        // GET: api/Adopted/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adopted>> GetAdopted(int id)
        {
            var adopted = await _context.adopted.FindAsync(id);

            if (adopted == null)
            {
                return NotFound();
            }

            return adopted;
        }

        // PUT: api/Adopted/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdopted(int id, Adopted adopted)
        {
            if (id != adopted.AdoptedId)
            {
                return BadRequest();
            }

            _context.Entry(adopted).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptedExists(id))
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

        // POST: api/Adopted
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Adopted>> PostAdopted(Adopted adopted)
        {
            _context.adopted.Add(adopted);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdopted", new { id = adopted.AdoptedId }, adopted);
        }

        // DELETE: api/Adopted/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Adopted>> DeleteAdopted(int id)
        {
            var adopted = await _context.adopted.FindAsync(id);
            if (adopted == null)
            {
                return NotFound();
            }

            _context.adopted.Remove(adopted);
            await _context.SaveChangesAsync();

            return adopted;
        }

        private bool AdoptedExists(int id)
        {
            return _context.adopted.Any(e => e.AdoptedId == id);
        }
    }
}
