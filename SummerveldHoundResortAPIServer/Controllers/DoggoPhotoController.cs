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
    public class DoggoPhotoController : ControllerBase
    {
        private readonly DoggoDataContext _context;

        public DoggoPhotoController(DoggoDataContext context)
        {
            _context = context;
        }

        // GET: api/DoggoPhoto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoggoPhoto>>> GetdoggoPhoto()
        {
            return await _context.doggoPhoto.ToListAsync();
        }

        // GET: api/DoggoPhoto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoggoPhoto>> GetDoggoPhoto(int id)
        {
            var doggoPhoto = await _context.doggoPhoto.FindAsync(id);

            if (doggoPhoto == null)
            {
                return NotFound();
            }

            return doggoPhoto;
        }

        // PUT: api/DoggoPhoto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoggoPhoto(int id, DoggoPhoto doggoPhoto)
        {
            if (id != doggoPhoto.DoggoPhotoId)
            {
                return BadRequest();
            }

            _context.Entry(doggoPhoto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoggoPhotoExists(id))
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

        // POST: api/DoggoPhoto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DoggoPhoto>> PostDoggoPhoto(DoggoPhoto doggoPhoto)
        {
            _context.doggoPhoto.Add(doggoPhoto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoggoPhoto", new { id = doggoPhoto.DoggoPhotoId }, doggoPhoto);
        }

        // DELETE: api/DoggoPhoto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DoggoPhoto>> DeleteDoggoPhoto(int id)
        {
            var doggoPhoto = await _context.doggoPhoto.FindAsync(id);
            if (doggoPhoto == null)
            {
                return NotFound();
            }

            _context.doggoPhoto.Remove(doggoPhoto);
            await _context.SaveChangesAsync();

            return doggoPhoto;
        }

        private bool DoggoPhotoExists(int id)
        {
            return _context.doggoPhoto.Any(e => e.DoggoPhotoId == id);
        }
    }
}
