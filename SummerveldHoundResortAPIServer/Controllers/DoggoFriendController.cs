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
    public class DoggoFriendController : ControllerBase
    {
        private readonly DoggoDataContext _context;

        public DoggoFriendController(DoggoDataContext context)
        {
            _context = context;
        }

        // GET: api/DoggoFriend
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoggoFriend>>> GetdoggoFriend()
        {
            return await _context.doggoFriend.ToListAsync();
        }

        // GET: api/DoggoFriend/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoggoFriend>> GetDoggoFriend(int id)
        {
            var doggoFriend = await _context.doggoFriend.FindAsync(id);

            if (doggoFriend == null)
            {
                return NotFound();
            }

            return doggoFriend;
        }

        // PUT: api/DoggoFriend/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoggoFriend(int id, DoggoFriend doggoFriend)
        {
            if (id != doggoFriend.DoggoFriendId)
            {
                return BadRequest();
            }

            _context.Entry(doggoFriend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoggoFriendExists(id))
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

        // POST: api/DoggoFriend
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DoggoFriend>> PostDoggoFriend(DoggoFriend doggoFriend)
        {
            _context.doggoFriend.Add(doggoFriend);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoggoFriend", new { id = doggoFriend.DoggoFriendId }, doggoFriend);
        }

        // DELETE: api/DoggoFriend/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DoggoFriend>> DeleteDoggoFriend(int id)
        {
            var doggoFriend = await _context.doggoFriend.FindAsync(id);
            if (doggoFriend == null)
            {
                return NotFound();
            }

            _context.doggoFriend.Remove(doggoFriend);
            await _context.SaveChangesAsync();

            return doggoFriend;
        }

        private bool DoggoFriendExists(int id)
        {
            return _context.doggoFriend.Any(e => e.DoggoFriendId == id);
        }
    }
}
