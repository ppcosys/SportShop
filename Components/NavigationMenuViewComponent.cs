using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IShopRepository repository;

        public NavigationMenuViewComponent(IShopRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];


            return View(
                repository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(p => p)
                );
        }
    }
}
