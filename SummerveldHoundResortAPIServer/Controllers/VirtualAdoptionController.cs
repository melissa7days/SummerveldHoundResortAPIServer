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
    public class VirtualAdoptionController : ControllerBase
    {
        private readonly DoggoDataContext _context;

        public VirtualAdoptionController(DoggoDataContext context)
        {
            _context = context;
        }

        //http://localhost:50367/api/virtualadoption/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VirtualAdoption>>> GetvirtualAdoption()
        {
            return await _context.virtualAdoption.ToListAsync();
        }

        //http://localhost:50367/api/virtualadoption/getVirtualAdoptionByDoggoId?doggoId=
        [HttpGet]
        [Route("getVirtualAdoptionByDoggoId")]
        public async Task<ActionResult<IEnumerable<VirtualAdoption>>> getDoggoById(int doggoId)
        {
            return await _context.virtualAdoption.FromSqlInterpolated($"CALL getVirtualAdoptionByDoggoId({doggoId})").ToListAsync();
        }

        // PUT: api/VirtualAdoption/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVirtualAdoption(int id, VirtualAdoption virtualAdoption)
        {
            if (id != virtualAdoption.VirtualAdoptionId)
            {
                return BadRequest();
            }

            _context.Entry(virtualAdoption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VirtualAdoptionExists(id))
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

        // POST: api/VirtualAdoption
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VirtualAdoption>> PostVirtualAdoption(VirtualAdoption virtualAdoption)
        {
            _context.virtualAdoption.Add(virtualAdoption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVirtualAdoption", new { id = virtualAdoption.VirtualAdoptionId }, virtualAdoption);
        }

        // DELETE: api/VirtualAdoption/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VirtualAdoption>> DeleteVirtualAdoption(int id)
        {
            var virtualAdoption = await _context.virtualAdoption.FindAsync(id);
            if (virtualAdoption == null)
            {
                return NotFound();
            }

            _context.virtualAdoption.Remove(virtualAdoption);
            await _context.SaveChangesAsync();

            return virtualAdoption;
        }

        private bool VirtualAdoptionExists(int id)
        {
            return _context.virtualAdoption.Any(e => e.VirtualAdoptionId == id);
        }
    }
}
