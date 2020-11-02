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
    public class IntroController : ControllerBase
    {
        private readonly DoggoDataContext _context;

        public IntroController(DoggoDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intro>>> Getintro()
        {
            return await _context.intro.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Intro>> GetIntro(int id)
        {
            var intro = await _context.intro.FindAsync(id);

            if (intro == null)
            {
                return NotFound();
            }

            return intro;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntro(int id, Intro intro)
        {
            if (id != intro.IntroId)
            {
                return BadRequest();
            }

            _context.Entry(intro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntroExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Intro>> PostIntro(Intro intro)
        {
            _context.intro.Add(intro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntro", new { id = intro.IntroId }, intro);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Intro>> DeleteIntro(int id)
        {
            var intro = await _context.intro.FindAsync(id);
            if (intro == null)
            {
                return NotFound();
            }

            _context.intro.Remove(intro);
            await _context.SaveChangesAsync();

            return intro;
        }

        private bool IntroExists(int id)
        {
            return _context.intro.Any(e => e.IntroId == id);
        }
    }
}
