using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart); 
        }
    }
}
