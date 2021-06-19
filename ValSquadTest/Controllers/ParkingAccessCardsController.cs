using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValSquadTest.Models;

namespace ValSquadTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingAccessCardsController : ControllerBase
    {
        private readonly ValTestContext _context;

        public ParkingAccessCardsController(ValTestContext context)
        {
            _context = context;
        }

        // GET: api/ParkingAccessCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingAccessCard>>> GetParkingAccessCards()
        {
            return await _context.ParkingAccessCards.ToListAsync();
        }

        // GET: api/ParkingAccessCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingAccessCard>> GetParkingAccessCard(int id)
        {
            var parkingAccessCard = await _context.ParkingAccessCards.FindAsync(id);

            if (parkingAccessCard == null)
            {
                return NotFound();
            }

            return parkingAccessCard;
        }

        // PUT: api/ParkingAccessCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParkingAccessCard(int id, ParkingAccessCard parkingAccessCard)
        {
            if (id != parkingAccessCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(parkingAccessCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingAccessCardExists(id))
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

        // POST: api/ParkingAccessCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParkingAccessCard>> PostParkingAccessCard(ParkingAccessCard parkingAccessCard)
        {
            _context.ParkingAccessCards.Add(parkingAccessCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParkingAccessCard", new { id = parkingAccessCard.Id }, parkingAccessCard);
        }

        // DELETE: api/ParkingAccessCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParkingAccessCard(int id)
        {
            var parkingAccessCard = await _context.ParkingAccessCards.FindAsync(id);
            if (parkingAccessCard == null)
            {
                return NotFound();
            }

            _context.ParkingAccessCards.Remove(parkingAccessCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParkingAccessCardExists(int id)
        {
            return _context.ParkingAccessCards.Any(e => e.Id == id);
        }
    }
}
