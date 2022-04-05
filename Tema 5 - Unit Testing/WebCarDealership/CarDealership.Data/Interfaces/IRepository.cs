using CarDealership.Data.Models;

namespace CarDealership.Data.Interfaces
{
    public interface IRepository
    {
        Task<CarOffer> GetCarOfferById(int id);
        void AddOrder(Order order);
        Task<Order> GetOrderById(int id);
        Task<int> SaveChanges();
    }
}
