using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        
        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            var products = _manager.ProductService.GetAllProduct(false);
            return View(products);
        }
        public IActionResult Get([FromRoute(Name ="id")]int id) {
            //Product product = _manager.Product.GetOneProduct(id, false);
            var model = _manager.ProductService.GetOneProductForUpdate(id,false);
            return View(model);
        }
    }
}
