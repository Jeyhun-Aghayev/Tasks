using AuthenticationApplication.Models;
using AuthenticationApplication.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly IPasswordValidator<ApplicationUser> _passwordValidator;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public UserController(UserManager<ApplicationUser> userManager, IPasswordValidator<ApplicationUser> passwordValidator, RoleManager<ApplicationRole> roleManager)
        {
            _UserManager = userManager;
            _passwordValidator = passwordValidator;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()=>View(await _UserManager.Users.ToListAsync());
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create([Bind("UserName , Password , Email")] RegisterUserDto model) 
        {
            if (ModelState.IsValid) 
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await _UserManager.CreateAsync(user,model.Password);
                    if (result.Succeeded)
                    {
                        string defaultRole = "User";
                        if(!await _roleManager.RoleExistsAsync(defaultRole))
                        {
                            await _roleManager.CreateAsync(new ApplicationRole { Name = defaultRole });
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

    }
}
