using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApplication.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
