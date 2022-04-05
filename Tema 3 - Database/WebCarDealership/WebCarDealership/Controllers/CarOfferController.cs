using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarOfferController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CarOfferController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("getAllCarOffers")]
        public async Task<IActionResult> Get()
        {
            var offers = await _dbContext.CarOffers.ToListAsync();
            return Ok(offers);
        }

        [HttpPost("addCarOffer")]
        public async Task<IActionResult> Post([FromBody] CarOfferRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbOffer = new CarOffer
            {
                Make = model.Make,
                Model = model.Model,
                AvailableStock = model.AvailableStock
            };

            _dbContext.CarOffers.Add(dbOffer);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbOffer);
        }

        [HttpPatch("updateCarOffer")]
        public async Task<IActionResult> Update(int _carId, string _paramToChange, string _newStringValue) //ask
        {
            foreach (var customer in _dbContext.CarOffers)
            {
                if (customer.Id == _carId)
                {
                    if (_paramToChange == "make")
                    {
                        customer.Make = _newStringValue;
                        break;
                    }
                    else if (_paramToChange == "model")
                    {
                        customer.Model = _newStringValue;
                        break;
                    }
                    else if (_paramToChange == "availableStock")
                    {
                        try
                        {
                            customer.AvailableStock = Convert.ToInt32(_newStringValue);
                        }
                        catch (InvalidCastException e)
                        {
                            return BadRequest("Please provide a valid value");
                        }
                    }
                    else
                        return BadRequest("Please provide a valid parameter");
                }
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }



        [HttpDelete("deleteCarOffer")]
        public async Task<IActionResult> Remove(int _carId)
        {
            foreach (var carOffer in _dbContext.CarOffers)
            {
                if (carOffer.Id == _carId)
                {
                    _dbContext.CarOffers.Remove(carOffer);
                    break;
                }
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}