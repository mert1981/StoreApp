using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructe.Extensions;
using System.Globalization;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {

        private readonly IServiceManager _manager;
        public Cart Cart {  get; set; }
        public string ReturnUrl { get; set; } = "/";

        public CartModel(IServiceManager manager)
        {
            _manager = manager;
           
        }

        
        public void OnGet(string returnUrl) 
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int id, string returnUrl)
        {
            Product? product = _manager.ProductService.GetOneProduct(id, false);
            if (product is not null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson<Cart>("cart",Cart);

            }
            return Page();
        }
        public IActionResult OnPostRemove(int id,string returnUrl)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.Id == id).Product);
            HttpContext.Session.SetJson<Cart>("cart", Cart);
            return Page();
        }
    }
}