using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Entities.Models;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller 

    {
        private readonly IRepositoryManager _repositoryManager;
        public CategoryController(IRepositoryManager repository)
        {
            _repositoryManager = repository;
        }
        
        public IActionResult Index()
        {
            var model = _repositoryManager.Category.FindAll(false);
            return View(model);
            
        }
    }
}
