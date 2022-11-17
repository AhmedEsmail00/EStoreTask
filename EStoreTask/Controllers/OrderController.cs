using EStoreTask.Data;
using EStoreTask.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EStoreTask.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepo _repo;

        public OrderController(IOrderRepo repo)
        {
            _repo = repo;

        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(UserRole.AdminRole))
            {
               

                var orders =await _repo.GetOrders();
                if(orders is not null)
                {
                    return View(orders);
                }
            }
            if (User.IsInRole(UserRole.DefaultRole))
            {
                string UserId= User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var orders =await _repo.GetOrdersByUserId(UserId);
                if (orders is not null)
                {
                    return View(orders);
                }
            }
            return View();
        }
    }
}
