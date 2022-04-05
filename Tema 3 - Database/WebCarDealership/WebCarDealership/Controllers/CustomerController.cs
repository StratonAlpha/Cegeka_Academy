using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CustomerController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CustomerController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("getAllCustomers")]
        public async Task<IActionResult> Get()
        {
            var controller = await _dbContext.Customers.ToListAsync();
            return Ok(controller);
        }

        [HttpPost("addCustomer")]
        public async Task<IActionResult> Post([FromBody] CustomerRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbCustomer = new Customer
            {
                Name = model.Name,
                Email = model.Email,
            };

            _dbContext.Customers.Add(dbCustomer);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbCustomer);
        }

        [HttpPatch("updateCustomer")]
        public async Task<IActionResult> Update(int _customerId, string _paramToChange, string _newValue)
        {
            foreach (var customer in _dbContext.Customers)
            {
                if (customer.Id == _customerId)
                {
                    if (_paramToChange == "Name")
                    {
                        customer.Name = _newValue;
                        break;
                    }
                    else if (_paramToChange == "Email")
                    {
                        customer.Email = _newValue;
                        break;
                    }
                    else
                        return BadRequest("Please provide a valid parameter to be changed");
                }
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("deleteCustomer")]
        public async Task<IActionResult> Remove(int _customerId)
        {
            foreach (var customer in _dbContext.Customers)
            {
                if (customer.Id == _customerId)
                {
                    _dbContext.Customers.Remove(customer);
                    break;
                }
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
