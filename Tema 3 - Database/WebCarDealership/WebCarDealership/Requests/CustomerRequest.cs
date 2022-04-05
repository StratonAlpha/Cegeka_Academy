using System.ComponentModel.DataAnnotations;

namespace WebCarDealership.Requests
{
    public class CustomerRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
