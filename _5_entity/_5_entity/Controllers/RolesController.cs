using _5_entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _5_entity.Controllers;

public class RolesController : Controller
{
    private readonly RoleManager<AppRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;
    public RolesController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
    
    public IActionResult Index()
    {
        return View(_roleManager.Roles);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(AppRole model)
    {
        if (ModelState.IsValid)
        {
            var result = await _roleManager.CreateAsync(model);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
        }
        return View(model);
    }

    public async Task<IActionResult> Edit(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role != null && role.Name != null)
        {
            ViewBag.Users = await _userManager.GetUsersInRoleAsync(role.Name);
            return View(role);
        }
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(string id, AppRole model)
    {
        if (ModelState.IsValid)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ModelState.AddModelError("", "Role not found.");
                return View(model); // Hata varsa tekrar formu göster
            }

            role.Name = model.Name;

            var result = await _roleManager.UpdateAsync(role); // Burada role artık kesinlikle null değil

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }

            if (role.Name != null)
            {
                ViewBag.Users = await _userManager.GetUsersInRoleAsync(role.Name);
            }
        }

        return View(model);
    }
}