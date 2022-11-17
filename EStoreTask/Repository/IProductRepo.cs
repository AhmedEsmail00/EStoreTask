using EStoreTask.Models;
using System.Collections.Generic;

namespace EStoreTask.Repository
{
    public interface IProductRepo
    {

        public Task<IEnumerable<Product>> GetProducts();
        public Task<bool> AddProduct(Product product);

        public Task<bool> SaveChanges();
    }
}
