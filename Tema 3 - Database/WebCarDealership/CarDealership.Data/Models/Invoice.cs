namespace CarDealership.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Amount { get; set; }

        //public ICollection<Order> Orders { get; set; }
    }
}
