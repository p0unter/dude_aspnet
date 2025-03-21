using _5_entity.Models;
using _5_entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _5_entity.Controllers;

[Authorize(Roles = "admin")]
public class UsersController : Controller
{
    private UserManager<AppUser> _userManager;
    private RoleManager<AppRole> _roleManager;

    public UsersController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    // [AllowAnonymous] // for show
    public IActionResult Index()
    {
        /*
        if (!User.IsInRole("admin"))
        {
            return Unauthorized();
        }
        */
        
        return View(_userManager.Users);
    }
    
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }
        
        var user = await _userManager.FindByIdAsync(id);

        if (user != null)
        {
            ViewBag.Roles = await _roleManager.Roles.Select(i => i.Name).ToListAsync();
            return View(new EditViewModel
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                SelectedRoles = await _userManager.GetRolesAsync(user)
            });

        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, EditViewModel model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = model.Email;
                user.FullName = model.FullName;
            
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded && !string.IsNullOrEmpty(model.Password))
                {
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, model.Password);
                }
            
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role);
                    }
                
                    if (model.SelectedRoles != null && model.SelectedRoles.Any())
                    {
                        await _userManager.AddToRolesAsync(user, model.SelectedRoles);
                    }
                    return RedirectToAction("Index");
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
        }
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            await _userManager.DeleteAsync(user);
        }
        return RedirectToAction("Index");
    }
}