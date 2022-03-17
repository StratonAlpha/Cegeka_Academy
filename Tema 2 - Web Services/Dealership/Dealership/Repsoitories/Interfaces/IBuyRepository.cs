using Dealership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Repsoitories
{
    public interface IBuyRepository
    {
        public List<Buy> GetBuy();
        public void Buy(int idCar, int idCustomer, int stock);
        public List<Buy> FilterBuy(string param, string filter);
    }
}
