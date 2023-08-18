using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirlineManagementAPI.Models.EF;

namespace AirlineManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightInfoController : ControllerBase
    {
        private readonly AirlinesManagementContext _context;

        public FlightInfoController(AirlinesManagementContext context)
        {
            _context = context;
        }

        // GET: api/FlightInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightInfo>>> GetFlightInfos()
        {
          if (_context.FlightInfos == null)
          {
              return NotFound();
          }
            return await _context.FlightInfos.ToListAsync();
        }

        // GET: api/FlightInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightInfo>> GetFlightInfo(int id)
        {
          if (_context.FlightInfos == null)
          {
              return NotFound();
          }
            var flightInfo = await _context.FlightInfos.FindAsync(id);

            if (flightInfo == null)
            {
                return NotFound();
            }

            return flightInfo;
        }

        // PUT: api/FlightInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightInfo(int id, FlightInfo flightInfo)
        {
            if (id != flightInfo.FlightNo)
            {
                return BadRequest();
            }

            _context.Entry(flightInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightInfoExists(id))
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

        // POST: api/FlightInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlightInfo>> PostFlightInfo(FlightInfo flightInfo)
        {
          if (_context.FlightInfos == null)
          {
              return Problem("Entity set 'AirlinesManagementContext.FlightInfos'  is null.");
          }
            _context.FlightInfos.Add(flightInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FlightInfoExists(flightInfo.FlightNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFlightInfo", new { id = flightInfo.FlightNo }, flightInfo);
        }

        // DELETE: api/FlightInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightInfo(int id)
        {
            if (_context.FlightInfos == null)
            {
                return NotFound();
            }
            var flightInfo = await _context.FlightInfos.FindAsync(id);
            if (flightInfo == null)
            {
                return NotFound();
            }

            _context.FlightInfos.Remove(flightInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightInfoExists(int id)
        {
            return (_context.FlightInfos?.Any(e => e.FlightNo == id)).GetValueOrDefault();
        }
    }
}
