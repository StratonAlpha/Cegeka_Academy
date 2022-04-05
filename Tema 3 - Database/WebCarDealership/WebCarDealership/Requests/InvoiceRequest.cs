using System.ComponentModel.DataAnnotations;

namespace WebCarDealership.Requests
{
    public class InvoiceRequest
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string InvoiceNumber { get; set; }
    }
}
