using System;

namespace RentalCars
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalCars storeIasi = new RentalCars(Showroom.Iasi);
            RentalCars storeBucharest = new RentalCars(Showroom.Bucharest);

            var ion = new Customer("Ion Popescu");
            var mihai = new Customer("Mihai Chirica");
            var gigi = new Customer("Gigi Becali");
            var nerd = new Customer("Robot Girlyman");
            var cato = new Customer("I Cato Sicarius");
            var marneus = new Customer("Marenus Calgar");

            storeIasi.AddRental(ion, new Car(PriceCode.Regular, "Ford Focus"), 2);
            storeIasi.AddRental(gigi, new Car(PriceCode.Regular, "Renault Clio"), 3);
            storeIasi.AddRental(ion, new Car(PriceCode.Premium, "BMW 330i"), 1);
            storeIasi.AddRental(gigi, new Car(PriceCode.Premium, "Volvo XC90"), 3);
            storeIasi.AddRental(mihai, new Car(PriceCode.Mini, "Toyota Aygo"), 2);
            storeIasi.AddRental(ion, new Car(PriceCode.Premium, "Hyundai i10"), 4);
            storeIasi.AddRental(gigi, new Car(PriceCode.Luxury, "AvtoVAZ Lada"), 2);
            storeIasi.AddRental(gigi, new Car(PriceCode.Premium, "Mercedes E320"), 1);

            storeBucharest.AddRental(cato, new Car(PriceCode.Regular, "Ford Focus"), 2);
            storeBucharest.AddRental(nerd, new Car(PriceCode.Regular, "Renault Clio"), 3);
            storeBucharest.AddRental(cato, new Car(PriceCode.Luxury, "BMW 330i"), 1);
            storeBucharest.AddRental(nerd, new Car(PriceCode.Premium, "Volvo XC90"), 3);
            storeBucharest.AddRental(marneus, new Car(PriceCode.Mini, "Toyota Aygo"), 2);
            storeBucharest.AddRental(cato, new Car(PriceCode.Premium, "Hyundai i10"), 4);
            storeBucharest.AddRental(nerd, new Car(PriceCode.Luxury, "AvtoVAZ Lada"), 2);
            storeBucharest.AddRental(nerd, new Car(PriceCode.Premium, "Mercedes E320"), 1);

            Console.WriteLine(storeIasi.Statement());
            Console.WriteLine(storeIasi.StatementPreference());
            Console.WriteLine(storeBucharest.Statement());
            Console.WriteLine(storeBucharest.StatementPreference());
            Console.ReadKey();

        }
    }
}
