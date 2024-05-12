using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly RepositoryContext _repositoryContext;
        
        public ProductController(RepositoryContext context)
        {
            _repositoryContext = context;
        }
        public IActionResult Index()
        {
            var products = _repositoryContext.Products.ToList();
            return View(products);
        }
        public IActionResult Get(int id) {
            Product product = _repositoryContext.Products.First(p => p.Id == id); 
            return View(product);
        }
    }
}
