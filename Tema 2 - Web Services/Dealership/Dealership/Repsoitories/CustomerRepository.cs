using Dealership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Repsoitories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void AddCustomer(Customer customer)
        {
            DepositCustomer.Add(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return DepositCustomer.GetAll();
        }
    }
}
