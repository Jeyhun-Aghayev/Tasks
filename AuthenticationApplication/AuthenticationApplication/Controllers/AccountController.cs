using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApplication.Controllers
{

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
