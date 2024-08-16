using AuthenticationApplication.Models;
using AuthenticationApplication.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApplication.Controllers;

public class RoleController : Controller
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager  ;

    public RoleController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index() => View(await _roleManager.Roles.ToListAsync());
    public IActionResult Create() => View();
    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleDto model)
    {
        if (ModelState.IsValid)
        {
            var role = new ApplicationRole
            {
                Name = model.Name.Replace(" ", ""),
                ExpireDate = model.ExpireDate
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        return View(model);
    }

    public async Task<IActionResult> Edit(int id)
    {

        ApplicationRole role = await _roleManager.FindByIdAsync(id.ToString());
        // bu liste içerisinde, bu role sahip kullanıcıların listesi olacak
        var members = new List<ApplicationUser>();
        // bu liste içerisinde,bu role sahip olmayan kullanıcıların listesi olacak
        var nonMembers = new List<ApplicationUser>();


        foreach (var user in _userManager.Users)
        {
            var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
            list.Add(user);
        }


        var dto = new RoleDetailsDto
        {
            Role = role,
            Members = members,
            NonMembers = nonMembers
        };

        return View(dto);
    }
}
