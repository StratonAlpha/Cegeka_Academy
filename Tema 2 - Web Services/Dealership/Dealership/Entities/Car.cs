namespace Dealership.Entities
{
    public class Car
    {
        public static int id = 1;
        public int Id { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public Car() { }
        public Car(CarRequest car)
        {
            Id = id;
            Brand = car.Brand;
            Model = car.Model;
            Stock = car.Stock;

            id++;
        }

        public void Sell(int stock)
        {
            Stock -= stock;
        }
    }
}
