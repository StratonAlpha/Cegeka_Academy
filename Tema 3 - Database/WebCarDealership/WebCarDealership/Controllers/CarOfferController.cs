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
        public async Task<IActionResult> Update(int _carId, string _paramToChange, string _newStringValue)
        {

            var offer = await _dbContext.CarOffers.FirstOrDefaultAsync(offer => offer.Id == _carId);

            if(offer == null)
            {
                return NotFound();
            }

            switch (_paramToChange)
            {
                case "Make":
                    offer.Make = _newStringValue;
                    break;
                case "Model":
                    offer.Model = _newStringValue;
                    break;
                case "AvailableStock":
                    try
                    {
                        offer.AvailableStock = Convert.ToInt32(_newStringValue);
                    }
                    catch (InvalidCastException e)
                    {
                        return BadRequest("Please provide a valid value");
                    }
                    break;

                default:
                    return BadRequest("Please provide a valid parameter");
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }



        [HttpDelete("deleteCarOffer")]
        public async Task<IActionResult> Remove(int _carId)
        {

            var offer = await _dbContext.CarOffers.FirstOrDefaultAsync(offer => offer.Id==_carId);

            if( offer == null)
            {
                return NotFound();
            }

            _dbContext.CarOffers.Remove(offer);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}