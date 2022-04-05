using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public OrderController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var order = await _dbContext.Orders.ToListAsync();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var offer = await _dbContext.CarOffers.FirstOrDefaultAsync(offer => offer.Id == model.CarOfferId);
            if (offer == null)
            {
                return NotFound("car offer not found");
            }

            var customer = await _dbContext.Customers.FirstOrDefaultAsync(customer => customer.Id == model.CustomerId);
            if (customer == null)
            {
                return NotFound("customer not found");
            }

            if (offer.AvailableStock <= model.Quantity)
            {
                return BadRequest("Not enough cars of this model are available in stock!");
            }

            offer.AvailableStock -= model.Quantity;

            var dbOrder = new Order()
            {
                CarOfferId = model.CarOfferId,
                CustomerId = model.CustomerId,
                Date = DateTime.UtcNow,
                Quantity = model.Quantity
            };
            _dbContext.Orders.Add(dbOrder);

            int numberOfRecordsAffected = await _dbContext.SaveChangesAsync();

            if (numberOfRecordsAffected == 0)
            {
            }

            return Created(Request.GetDisplayUrl(), dbOrder);
        }

        [HttpGet("filterQuersyString.NotWorking")]
        public async Task<IActionResult> Filter([FromQuery(Name = "CustomerId")] int Id)
        {
            if (Id == 0)
                return BadRequest(); //should add this to the rest
            else
            {
                var order = await _dbContext.Orders.FirstOrDefaultAsync(order => order.CustomerId == Id);
                return Ok(order);
            }
        }

        [HttpGet("filterWorking.NoQuerryString")]
        public async Task<IActionResult> FilterCheat(int value)
        {
            return Ok(await _dbContext.Orders.FirstOrDefaultAsync(order => order.CustomerId == value));
        }
    }
}