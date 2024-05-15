using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;
        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProduct(false);
            return View(model);
        }
        public IActionResult Create() {
            ViewBag.Categories = _manager.CategoryService.GetAllCategories(false);

            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operation
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","img",file.FileName); //Uygulamamız sunucuda hangi klasörde çalışıyor bunu sunucudan alıyoruz.
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/img/",file.FileName);

                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
           return View();
        }
        
        public IActionResult Update([FromRoute(Name ="id")] int id)
        {
            ViewBag.Categories = _manager.CategoryService.GetAllCategories(false);
            var model = _manager.ProductService.GetOneProductForUpdate(id,false);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm]ProductDtoForUpdate productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operation
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", file.FileName); //Uygulamamız sunucuda hangi klasörde çalışıyor bunu sunucudan alıyoruz.
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/img/", file.FileName);

                _manager.ProductService.UpdateOneProduct(productDto);
                return RedirectToAction("Index");   
            }
            
           return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST([FromRoute(Name = "id")] int id )
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }
    }
}
