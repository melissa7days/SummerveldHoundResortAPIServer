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
    public class DoggoVideoController : ControllerBase
    {
        private readonly DoggoDataContext _context;

        public DoggoVideoController(DoggoDataContext context)
        {
            _context = context;
        }

        // GET: api/DoggoVideo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoggoVideo>>> GetdoggoVideo()
        {
            return await _context.doggoVideo.ToListAsync();
        }

        // GET: api/DoggoVideo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoggoVideo>> GetDoggoVideo(int id)
        {
            var doggoVideo = await _context.doggoVideo.FindAsync(id);

            if (doggoVideo == null)
            {
                return NotFound();
            }

            return doggoVideo;
        }

        // PUT: api/DoggoVideo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoggoVideo(int id, DoggoVideo doggoVideo)
        {
            if (id != doggoVideo.DoggoVideoId)
            {
                return BadRequest();
            }

            _context.Entry(doggoVideo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoggoVideoExists(id))
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

        // POST: api/DoggoVideo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DoggoVideo>> PostDoggoVideo(DoggoVideo doggoVideo)
        {
            _context.doggoVideo.Add(doggoVideo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoggoVideo", new { id = doggoVideo.DoggoVideoId }, doggoVideo);
        }

        // DELETE: api/DoggoVideo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DoggoVideo>> DeleteDoggoVideo(int id)
        {
            var doggoVideo = await _context.doggoVideo.FindAsync(id);
            if (doggoVideo == null)
            {
                return NotFound();
            }

            _context.doggoVideo.Remove(doggoVideo);
            await _context.SaveChangesAsync();

            return doggoVideo;
        }

        private bool DoggoVideoExists(int id)
        {
            return _context.doggoVideo.Any(e => e.DoggoVideoId == id);
        }
    }
}
