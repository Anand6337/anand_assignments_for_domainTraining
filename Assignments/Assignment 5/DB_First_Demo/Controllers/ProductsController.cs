using DB_First_Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DB_First_Demo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly BikeStoresContext _context;
        public ProductsController(BikeStoresContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        //Search functionality
        public IActionResult Search(string searchTerm)
        {
            var products = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => p.ProductName.Contains(searchTerm));
            }
            return View("Index", products.ToList());
        }
    }
}
