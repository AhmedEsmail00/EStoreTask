using EStoreTask.Models;
using Microsoft.EntityFrameworkCore;

namespace EStoreTask.Repository
{
    public class OrderRepo:IOrderRepo
    {
        private readonly EStoreDbContext _db;

        public OrderRepo(EStoreDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            var orders = await _db.Orders
                .Include(u=>u.User)
                .Include(o=>o.OrderDetails)
                .ToListAsync();
            return orders;
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserId(string UserId)
        {
           var orders=await _db.Orders.Include(u=>u.User)
                .Include(o=>o.OrderDetails)
                .Where(www=>www.User.Id== UserId)
                .ToListAsync();
            return orders;
        }




    
        public async Task<bool> AddOrder(Order order)
        {
            _db.Orders.Add(order);
            if (await SaveChanges())
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        public async Task<Order> GetOrderById(int OrderId)
        {
            var order = await _db.Orders
               .Include(o => o.OrderDetails)
               .Include(u=>u.User)
               .Where(o => o.OrderId == OrderId ).FirstOrDefaultAsync();
            return order;
        }

        public  async Task<bool> UpdateOrder(Order order)
        {
            var DbOrder = await GetOrderById(order.OrderId);
            if(DbOrder is not null)
            {
                DbOrder.TotalPrice = order.TotalPrice;
                if(await SaveChanges())
                {
                    return true;
                }
            }
            return false;
        }

      
        public async Task<bool> SaveChanges()
        {
            try
            {
                if (await _db.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

       
    }
}
