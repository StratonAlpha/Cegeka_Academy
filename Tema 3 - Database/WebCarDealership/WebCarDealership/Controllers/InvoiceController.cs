using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Requests;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("controller")]
    public class InvoiceController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public InvoiceController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllInvoices")]
        public async Task<IActionResult> Get()
        {
            var invoice = await _dbContext.Invoices.ToListAsync();
            return Ok(invoice);
        }

        [HttpPost("addInvoices")]
        public async Task<IActionResult> Post([FromBody] InvoiceRequest model)
        {
            var amount = 0;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _dbContext.Customers.FirstOrDefaultAsync(customer => customer.Id == model.CustomerId);
            if (customer == null)
            {
                return NotFound("customer not found");
            }

            var order = await _dbContext.Orders.FirstOrDefaultAsync(order => order.CustomerId == model.CustomerId);
            if (order == null)
            {
                return NotFound("customer hasn't place this order");
            }

            foreach(var orders in _dbContext.Orders)
            {
                if (orders.CustomerId == model.CustomerId)
                {
                    amount += orders.Quantity;
                }
            }

            foreach(var invoiceNumber in _dbContext.Invoices)
            {
                if(invoiceNumber.InvoiceNumber == model.InvoiceNumber)
                {
                    return BadRequest("Invoice Number aleready in use");
                }
            }

            var dbInvoice = new Invoice
            {
                CustomerId = model.CustomerId,
                InvoiceNumber = model.InvoiceNumber,
                InvoiceDate = DateTime.UtcNow,
                Amount = amount
            };

            _dbContext.Invoices.Add(dbInvoice);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbInvoice);
        }
    }
}
