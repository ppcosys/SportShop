using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Models.ViewModels;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private IShopRepository repository;
        public int PageSize = 2;

        public HomeController(IShopRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(string? category, int productPage = 1)
        {
            return View(new ProductListViewModel { 
                Products = repository.Products
                .Where(p => p.Category == category || category == null || category == "Products")
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products
                    .Where(p => p.Category == category || category == null || category == "Products")
                    .Count()
                }
                ,
                CurrentCategory = category
            });
        }
    }
}
