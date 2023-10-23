using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;

        public OrderController(IOrderRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        [HttpGet]
        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(cart.Lines.Count() == 0) { ModelState.AddModelError("", "There should be at least 1 product in Order"); }

            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Complited", new {orderId = order.OrderID});
            }
            else { return View(); }
        }
    }
}
