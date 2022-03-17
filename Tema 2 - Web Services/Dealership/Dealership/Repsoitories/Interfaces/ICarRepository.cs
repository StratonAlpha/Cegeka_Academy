using Dealership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Repsoitories
{
    public interface ICarRepository
    {
        public List<Car> GetAllCar();
        public void AddCar(Car storage);
        public void RemoveCar(int id);
        public void UpdateCar(int id, string model, string brand, int stock);
    }
}
