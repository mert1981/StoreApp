using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepositoryManager _manager;
        
        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            var products = _manager.Product.GetAllProducts(false);
            return View(products);
        }
        public IActionResult Get(int id) {
            //Product product = _manager.Product.GetOneProduct(id, false);
            var model = _manager.Product.GetOneProduct(id,false);
            return View(model);
        }
    }
}
