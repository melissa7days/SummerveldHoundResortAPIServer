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
    public class DoggoAlbumController : ControllerBase
    {
        private readonly DoggoDataContext _context;

        public DoggoAlbumController(DoggoDataContext context)
        {
            _context = context;
        }

        //http://localhost:50367/api/doggoalbum        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoggoAlbum>>> GetdoggoAlbum()
        {
            return await _context.doggoAlbum.ToListAsync();
        }

        //http://localhost:50367/api/doggoalbum/getDoggoAlbumById?doggoAlbumId=
        [HttpGet]
        [Route("getDoggoAlbumById")]
        public async Task<ActionResult<IEnumerable<DoggoAlbum>>> getDoggoById(int doggoAlbumId)
        {
            return await _context.doggoAlbum.FromSqlInterpolated($"CALL getDoggoAlbumById({doggoAlbumId})").ToListAsync();
        }

        //http://localhost:50367/api/doggoalbum?id=   
        [HttpPut]
        public async Task<IActionResult> PutDoggoAlbum(int id, DoggoAlbum doggoAlbum)
        {
            if (id != doggoAlbum.DoggoAlbumId)
            {
                return BadRequest();
            }
            doggoAlbum.DoggoAlbumDateCreated = DateTime.Now;


            _context.Entry(doggoAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoggoAlbumExists(id))
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

        //http://localhost:55928/api/doggoalbum
        [HttpPost]
        public async Task<ActionResult<DoggoAlbum>> PostDoggoAlbum(DoggoAlbum doggoAlbum)
        {
            doggoAlbum.DoggoAlbumDateCreated = DateTime.Now;

            _context.doggoAlbum.Add(doggoAlbum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoggoAlbum", new { id = doggoAlbum.DoggoAlbumId }, doggoAlbum);
        }

        //http://localhost:55928/api/doggo?id=
        [HttpDelete]
        public async Task<ActionResult<DoggoAlbum>> DeleteDoggoAlbum(int id)
        {
            var doggoAlbum = await _context.doggoAlbum.FindAsync(id);
            if (doggoAlbum == null)
            {
                return NotFound();
            }

            _context.doggoAlbum.Remove(doggoAlbum);
            await _context.SaveChangesAsync();

            return doggoAlbum;
        }

        private bool DoggoAlbumExists(int id)
        {
            return _context.doggoAlbum.Any(e => e.DoggoAlbumId == id);
        }
    }
}
