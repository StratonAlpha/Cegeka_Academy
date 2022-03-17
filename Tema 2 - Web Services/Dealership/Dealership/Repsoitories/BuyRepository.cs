using Dealership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Repsoitories
{
    public class BuyRepository : IBuyRepository
    {
        public void Buy(int idCar, int idCustomer, int stock)
        {
            DepositBuy.Add(new Buy(DepositCar.GetCar(idCar), DepositCustomer.GetCustomer(idCustomer), stock));
            DepositCar.GetCar(idCar).Sell(stock);
        }

        public List<Buy> FilterBuy(string param, string filter)
        {
            return DepositBuy.Filter(param, filter);
        }

        public List<Buy> GetBuy()
        {
            return DepositBuy.GetAll();
        }
    }
}
