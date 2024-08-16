using AuthenticationApplication.Models;
using AuthenticationApplication.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApplication.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto model,[FromQuery] string? ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.UserName) ?? await _userManager.FindByNameAsync(model.UserName);
                if(user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result  = await _signInManager.PasswordSignInAsync(user,model.Password,model.RememberMe,true);
                    if (result.Succeeded)
                    {
                        string decodeUrl = Uri.UnescapeDataString(ReturnUrl ?? String.Empty);
                        return Redirect(decodeUrl??@"\");   
                    }
                }
                ModelState.AddModelError("UserName", "Invalit UserName Or Password");
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
