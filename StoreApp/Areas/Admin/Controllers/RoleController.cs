using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class RoleController : Controller
    {
        private readonly IServiceManager _manager;

        public RoleController(IServiceManager manager)
        {
            _manager = manager;
        }
        public ActionResult Index()
        {
            var role = _manager.AuthService.Roles;
            return View(role);
        }
    }
}
