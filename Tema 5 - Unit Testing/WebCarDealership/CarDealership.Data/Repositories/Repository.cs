using CarDealership.Data.Interfaces;
using CarDealership.Data.Models;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;

namespace CarDealership.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly DealershipDbContext context;

        public Repository(DealershipDbContext context)
        {
            this.context = context;
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
        }

        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                var order = await context.Orders.FirstOrDefaultAsync(order => order.Id == id);
                return order;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CarOffer> GetCarOfferById(int id)
        {
            try
            {
                var offer = await context.CarOffers.FirstOrDefaultAsync(offer => offer.Id == id);
                return offer;
            } catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
    }
}
