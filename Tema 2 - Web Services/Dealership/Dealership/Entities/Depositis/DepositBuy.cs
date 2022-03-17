using System;
using System.Collections.Generic;

namespace Dealership.Entities
{
    public class DepositBuy
    {
        private static List<Buy> storage = new List<Buy>();
        public static void Add(Buy item)
        {
            storage.Add(item);
        }
        public static List<Buy> GetAll()
        {
            return storage;
        }
        public static List<Buy> Filter(string param, string filter)
        {
            List<Buy> filterStorage = new List<Buy>();
            switch (param)
            {
                case "Id":
                    for(int i = 0; i < storage.Count; i++)
                    {
                        if(storage[i].Id == int.Parse(filter))
                        {
                            filterStorage.Add(storage[i]);
                        }
                    }
                    break;
                case "AcqDate":
                    for (int i = 0; i < storage.Count; i++)
                    {
                        if (storage[i].AcqTime == Convert.ToDateTime(filter))
                        {
                            filterStorage.Add(storage[i]);
                        }
                    }
                    break;
                case "Stock":
                    for (int i = 0; i < storage.Count; i++)
                    {
                        if (storage[i].Stock == int.Parse(filter))
                        {
                            filterStorage.Add(storage[i]);
                        }
                    }
                    break;
                case "Model":
                    for (int i = 0; i < storage.Count; i++)
                    {
                        if (storage[i].Model == filter)
                        {
                            filterStorage.Add(storage[i]);
                        }
                    }
                    break;
                case "Brand":
                    for (int i = 0; i < storage.Count; i++)
                    {
                        if (storage[i].Brand == filter)
                        {
                            filterStorage.Add(storage[i]);
                        }
                    }
                    break;
                case "Name":
                    for (int i = 0; i < storage.Count; i++)
                    {
                        if (storage[i].Name == filter)
                        {
                            filterStorage.Add(storage[i]);
                        }
                    }
                    break;
                case "Surname":
                    for (int i = 0; i < storage.Count; i++)
                    {
                        if (storage[i].Surname == filter)
                        {
                            filterStorage.Add(storage[i]);
                        }
                    }
                    break;
            }
            return filterStorage;
        }
    }
}
