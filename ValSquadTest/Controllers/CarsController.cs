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
    public class CarsController : ControllerBase
    {
        private readonly ValTestContext _context;

        public CarsController(ValTestContext context)
        {
            _context = context;
        }

        //CRUD operations for car
        #region CRUD

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.Include("Card").ToListAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            //var car = await _context.Cars.FindAsync(id);
            var car = _context.Cars.Include("Card").Where(c => c.PlateNumber == id).FirstOrDefault();

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.PlateNumber)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.PlateNumber }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        //Check car existence
        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.PlateNumber == id);
        }

        //---------------------------------------------------------------------------------------------
       
        #region Simulate register a car

        //Register a car in the highway and creates it's access card
        [Route("[action]/{id}")]
        [HttpPost]
        public async Task<ActionResult<Car>> PostCarFirstTime(Car car)
        {
            if (!CarExists(car.PlateNumber))
            {
                ParkingAccessCard card = new ParkingAccessCard()
                {
                    Credit = 10
                };
                car.Card = card;
                _context.Cars.Add(car);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCar", new { id = car.PlateNumber }, car);
            }
            else
            {
                return BadRequest("Already Exists");
            }
        } 
        #endregion

        #region Simulate passing the highway 

        //Card charged 4 dollars when the car passes the highway
        [Route("[action]/{id}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarPassesHighway(int id, Car car)
        {
            Car oldCar = _context.Cars.Find(id);
            if (oldCar == null)
            {
                return NotFound();
            }
            else
            {
                var myCar = _context.Cars.Where(c => c.PassingTime.Value.AddSeconds(60) >= car.PassingTime && c.PlateNumber == car.PlateNumber).Include("Card").FirstOrDefault();
                if (myCar == null)
                {
                    myCar.Card.Credit -= 4;
                    await _context.SaveChangesAsync();
                    //return Ok(car);
                }
                //oldCar.Card.Credit -= 4;
                return Ok(myCar);
            }
        } 
        #endregion

    }
}
