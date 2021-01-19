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

        //http://localhost:50367/api/icon 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Icon>>> Geticon()
        {
            return await _context.icon.ToListAsync();
        }

        //http://localhost:50367/api/icon/getIconById?iconId=
        [HttpGet]
        [Route("getIconById")]
        public async Task<ActionResult<IEnumerable<Icon>>> getIconById(int iconId)
        {
            return await _context.icon.FromSqlInterpolated($"CALL getIconById({iconId})").ToListAsync();
        }

        //http://localhost:50367/api/icon?id=
        [HttpPut]
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

        //http://localhost:55928/api/icon
        [HttpPost]
        public async Task<ActionResult<Icon>> PostIcon(Icon icon)
        {
            _context.icon.Add(icon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIcon", new { id = icon.IconId }, icon);
        }

        //http://localhost:55928/api/icon?id=
        [HttpDelete]
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
