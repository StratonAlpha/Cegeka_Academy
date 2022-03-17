using System.Collections.Generic;

namespace Dealership.Entities
{
    public class DepositCar
    {
        private static List<Car>storage = new List<Car>();

        public static void Add(Car item)
        {
            storage.Add(item);
        }
        public static List<Car> GetAll()
        {
            return storage;
        }
        public static Car GetCar(int id)
        {
            Car toReturn = new Car();
            for(int i = 0; i < storage.Count; i++)
            {
                if(storage[i].Id == id)
                {
                    toReturn = storage[i];
                }
            }
            return toReturn;
        }
        public static void RemoveCar(int id)
        {
            if (storage.Count == 1)
            {
                storage[0] = null;
            }
            else
            {
                for (int i = 0; i < storage.Count; i++)
                {
                    if (storage[i].Id == id)
                    {
                        for (int j = i; j < storage.Count - 1; j++)
                        {
                            storage[j] = storage[j + 1];
                        }
                        storage.RemoveAt(storage.Count - 1);
                        break;
                    }
                }
            }
        }
        public static void UpdateCar(int id, string model, string brand, int stock)
        {
            for(int i = 0; i < storage.Count; i++)
            {
                if(storage[i].Id == id)
                {
                    storage[i].Model = model;
                    storage[i].Brand = brand;
                    storage[i].Stock = stock;
                }
            }
        }
    }
}
