using System.ComponentModel.DataAnnotations;

namespace WebCarDealership.Requests
{
    public class OrderRequestModel
    {
        [Required(ErrorMessage ="Please input a Cusomer ID")]
        [Display(Name ="*CustomerID")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage ="Please input an Offer ID")]
        [Display]
        public int CarOfferId { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}
