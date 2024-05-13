using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using StoreApp.Models;
using System.Globalization;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;
        
        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _serviceManager = manager;
        }
        public string Invoke()
        {
            return _serviceManager.ProductService.GetAllProduct(false).Count().ToString();
        }
    }
}
