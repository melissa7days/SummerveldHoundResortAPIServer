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
    public class DoggoTypeController : ControllerBase
    {
        private readonly DoggoDataContext _context;

        public DoggoTypeController(DoggoDataContext context)
        {
            _context = context;
        }

        // GET: api/DoggoType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoggoType>>> GetdoggoType()
        {
            return await _context.doggoType.ToListAsync();
        }

        // GET: api/DoggoType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoggoType>> GetDoggoType(int id)
        {
            var doggoType = await _context.doggoType.FindAsync(id);

            if (doggoType == null)
            {
                return NotFound();
            }

            return doggoType;
        }

        // PUT: api/DoggoType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoggoType(int id, DoggoType doggoType)
        {
            if (id != doggoType.DoggoTypeId)
            {
                return BadRequest();
            }

            _context.Entry(doggoType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoggoTypeExists(id))
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

        // POST: api/DoggoType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DoggoType>> PostDoggoType(DoggoType doggoType)
        {
            _context.doggoType.Add(doggoType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoggoType", new { id = doggoType.DoggoTypeId }, doggoType);
        }

        // DELETE: api/DoggoType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DoggoType>> DeleteDoggoType(int id)
        {
            var doggoType = await _context.doggoType.FindAsync(id);
            if (doggoType == null)
            {
                return NotFound();
            }

            _context.doggoType.Remove(doggoType);
            await _context.SaveChangesAsync();

            return doggoType;
        }

        private bool DoggoTypeExists(int id)
        {
            return _context.doggoType.Any(e => e.DoggoTypeId == id);
        }
    }
}
