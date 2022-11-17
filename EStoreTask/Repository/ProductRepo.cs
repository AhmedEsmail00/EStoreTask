using EStoreTask.Models;
using Microsoft.EntityFrameworkCore;

namespace EStoreTask.Repository
{
    public class ProductRepo:IProductRepo
    {
        private readonly EStoreDbContext _db;

        public ProductRepo(EStoreDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products =await _db.Products.ToListAsync();
            return products;
        }

        public async Task<bool> AddProduct(Product product)
        {
            _db.Products.Add(product);
            if (await SaveChanges())
            {
                return true;
            }
            else
            {

                return false;
            }
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
