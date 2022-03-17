using Dealership.Entities;
using Dealership.Repsoitories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dealership.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _customerRepository { get; set; }

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost("addCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerRequest customer)
        {
            _customerRepository.AddCustomer(new Customer(customer));
            return Ok();
        }

        [HttpGet("getCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            var cars = _customerRepository.GetAllCustomers();
            return Ok(cars);
        }
    }
}
