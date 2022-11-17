using EStoreTask.Models;
using EStoreTask.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EStoreTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepo _repo;

        public HomeController(IProductRepo repo)
        {
            _repo = repo;
        }

        public async Task< IActionResult> Index()
        {
            var products = await _repo.GetProducts();
            if(products is not null)
            {
            return View(products);

            }
            return NotFound();
        }

        //public async Task< IActionResult> AddToTempCart()
        //{
        //    var cart = new List<Product>();

        //}
    }
}
