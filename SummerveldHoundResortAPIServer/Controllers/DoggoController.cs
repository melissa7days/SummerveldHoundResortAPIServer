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
    public class DoggoController : ControllerBase
    {
        private readonly DoggoDataContext _context;

        public DoggoController(DoggoDataContext context)
        {
            _context = context;
        }

        //http://localhost:50367/api/doggo        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doggo>>> Getdoggo()
        {
            return await _context.doggo.ToListAsync();
        }

        //http://localhost:50367/api/doggo/getDoggoById?doggoId=
        [HttpGet]
        [Route("getDoggoById")]
        public async Task<ActionResult<IEnumerable<Doggo>>> getDoggoById(int doggoId)
        {
            return await _context.doggo.FromSqlInterpolated($"CALL getDoggoById({doggoId})").ToListAsync();
        }

        //http://localhost:50367/api/doggo?id=   
        [HttpPut]
        public async Task<IActionResult> PutDoggo(int id, Doggo doggo)
        {
            if (id != doggo.DoggoId)
            {
                return BadRequest();
            }
            doggo.DoggoDateCreated = DateTime.Now;

            _context.Entry(doggo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoggoExists(id))
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

        //http://localhost:55928/api/doggo
        [HttpPost]
        public async Task<ActionResult<Doggo>> PostDoggo(Doggo doggo)
        {
            doggo.DoggoDateCreated = DateTime.Now;
            _context.doggo.Add(doggo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoggo", new { id = doggo.DoggoId }, doggo);
        }

        //http://localhost:55928/api/doggo?id=
        [HttpDelete]
        public async Task<ActionResult<Doggo>> DeleteDoggo(int id)
        {
            var doggo = await _context.doggo.FindAsync(id);
            if (doggo == null)
            {
                return NotFound();
            }

            _context.doggo.Remove(doggo);
            await _context.SaveChangesAsync();

            return doggo;
        }

        private bool DoggoExists(int id)
        {
            return _context.doggo.Any(e => e.DoggoId == id);
        }
    }
}
