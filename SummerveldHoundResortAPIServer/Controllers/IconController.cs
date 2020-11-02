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
    public class IconController : ControllerBase
    {
        private readonly DoggoDataContext _context;

        public IconController(DoggoDataContext context)
        {
            _context = context;
        }

        // GET: api/Icon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Icon>>> Geticon()
        {
            return await _context.icon.ToListAsync();
        }

        // GET: api/Icon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Icon>> GetIcon(int id)
        {
            var icon = await _context.icon.FindAsync(id);

            if (icon == null)
            {
                return NotFound();
            }

            return icon;
        }

        // PUT: api/Icon/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIcon(int id, Icon icon)
        {
            if (id != icon.IconId)
            {
                return BadRequest();
            }

            _context.Entry(icon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IconExists(id))
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

        // POST: api/Icon
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Icon>> PostIcon(Icon icon)
        {
            _context.icon.Add(icon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIcon", new { id = icon.IconId }, icon);
        }

        // DELETE: api/Icon/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Icon>> DeleteIcon(int id)
        {
            var icon = await _context.icon.FindAsync(id);
            if (icon == null)
            {
                return NotFound();
            }

            _context.icon.Remove(icon);
            await _context.SaveChangesAsync();

            return icon;
        }

        private bool IconExists(int id)
        {
            return _context.icon.Any(e => e.IconId == id);
        }
    }
}
