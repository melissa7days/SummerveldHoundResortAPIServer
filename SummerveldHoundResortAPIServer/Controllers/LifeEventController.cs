using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SummerveldHoundResortAPIServer.Data;
using SummerveldHoundResortAPIServer.Models;
using SummerveldHoundResortAPIServer.Models.CustomModels;

namespace SummerveldHoundResortAPIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeEventController : ControllerBase
    {
        private readonly DoggoDataContext _context;

        public LifeEventController(DoggoDataContext context)
        {
            _context = context;
        }

        //http://localhost:50367/api/lifeevent 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LifeEvent>>> GetlifeEvent()
        {
            return await _context.lifeEvent.ToListAsync();
        }

        //http://localhost:55928/api/LifeEvent/getAllLifeEvents
        [HttpGet]
        [Route("getAllLifeEvents")]
        public async Task<ActionResult<IEnumerable<LifeEventViewModel>>> getAllLifeEvents()
        {
            return await _context.lifeEventViewModel.FromSqlInterpolated($"CALL getAllLifeEvents").ToListAsync();
        }

        //http://localhost:50367/api/lifeevent/getLifeEventById?doggoId=
        [HttpGet]
        [Route("getLifeEventById")]
        public async Task<ActionResult<IEnumerable<LifeEvent>>> getLifeEventById(int doggoId)
        {
            return await _context.lifeEvent.FromSqlInterpolated($"CALL getLifeEventById({doggoId})").ToListAsync();
        }

        //http://localhost:50367/api/lifeevent?id=
        [HttpPut]
        public async Task<IActionResult> PutLifeEvent(int id, LifeEvent lifeEvent)
        {
            if (id != lifeEvent.LifeEventId)
            {
                return BadRequest();
            }

            _context.Entry(lifeEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LifeEventExists(id))
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

        //http://localhost:55928/api/lifeevent
        [HttpPost]
        public async Task<ActionResult<LifeEvent>> PostLifeEvent(LifeEvent lifeEvent)
        {
            _context.lifeEvent.Add(lifeEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLifeEvent", new { id = lifeEvent.LifeEventId }, lifeEvent);
        }

        //http://localhost:55928/api/lifeevent?id=
        [HttpDelete]
        public async Task<ActionResult<LifeEvent>> DeleteLifeEvent(int id)
        {
            var lifeEvent = await _context.lifeEvent.FindAsync(id);
            if (lifeEvent == null)
            {
                return NotFound();
            }

            _context.lifeEvent.Remove(lifeEvent);
            await _context.SaveChangesAsync();

            return lifeEvent;
        }

        private bool LifeEventExists(int id)
        {
            return _context.lifeEvent.Any(e => e.LifeEventId == id);
        }
    }
}
