using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Entities
{
    public class Buy
    {
        public static int id = 1;
        public int Id { get; set; }
        public int Stock { get; set; }
        public DateTime AcqTime { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Model { get; set; }
        public string Brand{ get; set; }

        public Buy() { }
        public Buy(Car car, Customer customer, int stock)
        {
            Id = id;
            Stock = stock;
            AcqTime = DateTime.Today;
            Name = customer.Name;
            Surname = customer.Surname;
            Model = car.Model;
            Brand = car.Brand;

            id++;
        }
    }
}
