using System.Collections.Generic;

namespace RentalCars
{
    public class RentalCars
    {
        private readonly List<Rental> _rentals = new List<Rental>(); 
        double totalAmount = 0;

        public Showroom Showroom { get; }

        public double PricePerDay { get; }

        public RentalCars(Showroom showroom)
        {
            Showroom = showroom;
            if (showroom == Showroom.Iasi)
                PricePerDay = 20;
            else
                PricePerDay = 30;
        }

        public void AddRental(Customer customer, Car car, int daysRented)
        {
            if ((car.PriceCode == PriceCode.Luxury
                && Showroom == Showroom.Iasi) 
                || ((car.PriceCode == PriceCode.Luxury
                && customer.FrequentRenterPoints < 3))) // Ugliest thing I ever wrote, need to rework while(I.hasTime > 0)
            {
                System.Console.WriteLine("Invalid Operation for: " + customer.Name + "\n");
            }
            else
            {
                var rental = new Rental(customer, car, daysRented, PricePerDay);
                _rentals.Add(rental);
                rental.Customer.AddRental(rental);
            }
        }

        public string Statement()
        {
            var r = "Rental Record for Rental " + Showroom + "\n";
            r += "----------------------------------\n";

            foreach (var each in _rentals)
            {
                r += each.Customer.Name + "\t\t" + each.Car.Model + "\t" + each.DaysRented + "d \t" + each.Amount + " EUR\n";

                totalAmount += each.Amount;
            }
            r += "----------------------------------\n";
            r += "Total revenue " + totalAmount + " EUR\n";

            return r;
        }

        public string StatementPreference()
        {
            double regularAmount = 0;
            double premiumAmount = 0;
            double miniAmount = 0;
            double luxuryAmount = 0;

            var r = "Car Record for Rental " + Showroom + "\n";
            r += "---------------------------------\n";
            r += "**Category\t\tTotal Income**\n";

            foreach (var each in _rentals)
            {
                if(each.Car.PriceCode == PriceCode.Regular)
                    regularAmount += each.Amount;
                if (each.Car.PriceCode == PriceCode.Premium)
                    premiumAmount += each.Amount;
                if (each.Car.PriceCode == PriceCode.Mini)
                    miniAmount+= each.Amount;
                if (each.Car.PriceCode == PriceCode.Luxury)
                    luxuryAmount += each.Amount;
            }

            r += "Regular" + "\t\t\t" + regularAmount +" EURO\n";
            r += "Premium" + "\t\t\t" + premiumAmount + " EURO\n";
            r += "Mini" + "\t\t\t" + miniAmount + " EURO\n";
            if(Showroom == Showroom.Bucharest)
                r += "Luxury" + "\t\t\t" + luxuryAmount  + " EURO\n";
            return r;
        }
    }
}