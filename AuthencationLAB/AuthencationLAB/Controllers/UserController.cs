using AuthencationLAB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationLAB.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _UserManager;
        private readonly IPasswordValidator<AppUser> _passwordValidator;
        private readonly RoleManager<AppRole> _roleManager;


        public UserController(UserManager<AppUser> userManager, IPasswordValidator<AppUser> passwordValidator, RoleManager<AppRole> roleManager)
        {
            _UserManager = userManager;
            _passwordValidator = passwordValidator;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()=>View(await _UserManager.Users.ToListAsync());
        public IActionResult Create() => View();
       /*  [HttpPost]
       public async Task<IActionResult> Create([Bind("UserName , Password , Email")] RegisterUserDto model) 
        {
            if (ModelState.IsValid) 
            {
                var user = new AppUser { UserName = model.UserName, Email = model.Email };
                var result = await _UserManager.CreateAsync(user,model.Password);
                    if (result.Succeeded)
                    {
                        string defaultRole = "User";
                        if(!await _roleManager.RoleExistsAsync(defaultRole))
                        {
                            await _roleManager.CreateAsync(new AppRole { Name = defaultRole });
                        }
                        await _UserManager.AddToRoleAsync(user, defaultRole);
                        return RedirectToAction(nameof(Index));
                    }
                    else 
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
            }
                    return View(model);
        }
*/
    }
}
