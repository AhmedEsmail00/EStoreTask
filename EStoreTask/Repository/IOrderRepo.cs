using EStoreTask.Models;

namespace EStoreTask.Repository
{
    public interface IOrderRepo
    {
        public Task<IEnumerable<Order>> GetOrders();
        public Task<IEnumerable<Order>> GetOrdersByUserId(string UserId);

        public Task<bool> AddOrder(Order order);
        public Task<Order> GetOrderById(int OrderId);
        public Task<bool> UpdateOrder(Order order);
        public Task<bool> SaveChanges();

    }
}
