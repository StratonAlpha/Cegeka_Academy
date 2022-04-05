namespace RentalCars
{
    public class Rental
    {
        public Customer Customer { get; }
        public Car Car { get; }
        public int DaysRented { get; }
        public double PricePerDay { get; }
        public double Amount { get; set; }

        public Rental(Customer customer, Car car, int daysRented, double pricePerDay)
        {
            Customer = customer;
            Car = car;
            DaysRented = daysRented;
            PricePerDay = pricePerDay;
            SetFinalAmount(daysRented);
        }

        public void SetFinalAmount(int daysRented)
        {

            SetAmount(daysRented);

            GetRenterPoints(daysRented);

            if (Customer.FrequentRenterPoints >= 5
                && Car.PriceCode != PriceCode.Luxury)
            {
                Amount *= 0.95;
            }
        }
        
        public void SetAmount(int daysRented)
        {
            var luxuryPricePerDay = 70;
            if (Car.PriceCode == PriceCode.Regular)
            {
                Amount += PricePerDay * 2;
                if (daysRented > 2)
                    Amount += (daysRented - 2) * PricePerDay * 0.75;
            }

            if (Car.PriceCode == PriceCode.Premium)
            {
                Amount += daysRented * PricePerDay * 1.5;
            }

            if (Car.PriceCode == PriceCode.Mini)
            {
                Amount += PricePerDay * 3 * 0.75;
                if (daysRented > 3)
                    Amount += (daysRented - 3) * PricePerDay * 0.5;
            }

            if (Car.PriceCode == PriceCode.Luxury)
            {
                Amount += daysRented * luxuryPricePerDay;
            }
        }

        public void GetRenterPoints(int daysRented)
        {
            int frequentRenterPoints = 1;

            if (Car.PriceCode == PriceCode.Premium 
                && daysRented > 1)
                frequentRenterPoints++;

            Customer.FrequentRenterPoints += frequentRenterPoints;
        }

    }
}