using EStoreTask.Models;
using EStoreTask.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EStoreTask.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepo _repo;

        public ProductsController(IProductRepo repo)
        {
            _repo = repo;
        }

        [Authorize(Roles = "Admin")]
        public async Task< IActionResult> Index()
        {

            var products = await _repo.GetProducts();
            if (products is not null)
            {
                TempData["ProductsStatus"] = "Load";
                return View(products);

            }
            return View(new {message="No products Found"});


        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddProduct(Product product)
        {
            string message = "";
            if (await _repo.AddProduct(product))

            {
                message = "SUCCESS";
                return Json(new { Message = message });
            }
            message = "FAILED";

            return Json(new { Message = message });
        }
        [Authorize(Roles ="Admin")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _repo.GetProducts();
            if (products is not null)
            {
                TempData["ProductsStatus"] = "Load";
                return (products);

            }
            return products;
        }



    }
}
