using _5_entity.Models;
using _5_entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace _5_entity.Controllers;

public class AccountController : Controller
{
    private UserManager<AppUser> _userManager;
    private RoleManager<AppRole> _roleManager;
    private SignInManager<AppUser> _signInManager;
    private IEmailSender _emailSender;

    public AccountController(
        UserManager<AppUser> userManager,
        RoleManager<AppRole> roleManager,
        SignInManager<AppUser> signInManager,
        IEmailSender emailSender)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
    }

    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                await _signInManager.SignOutAsync();

                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("", "Your email is not confirmed.");
                    return View(model);
                }
                
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    await _userManager.ResetAccessFailedCountAsync(user);
                    await _userManager.SetLockoutEndDateAsync(user, null);
                    
                    return RedirectToAction("Index", "Home");
                }
                else if (result.IsLockedOut)
                {
                    var lockoutEndDate = await _userManager.GetLockoutEndDateAsync(user);
                    var timeLeft = lockoutEndDate - DateTime.UtcNow;
                    ModelState.AddModelError(string.Empty, $"Your account has been locked, please try again in {timeLeft} minutes.");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid password.");
                }
            }
            else
            {
                ModelState.AddModelError("", "This email address not found.");
            }
        }
        return View(model);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                token = Uri.EscapeDataString(token);

                var url = Url.Action("ConfirmEmail", "Account", 
                    new { userId = user.Id, token = token }, Request.Scheme);

                // Vith SMTP Server
                /*
                var emailSubject = "Account Confirmation";
                var emailMessage = $@"
                <h1>Welcome to Our Service!</h1>
                <p>Please confirm your account by clicking the link below:</p>
                <a href='{url}'>Confirm your account</a>
                <p>Thank you!</p>";

                await _emailSender.SendEmailAsync(user.Email, emailSubject, emailMessage);
                */
                
                TempData["message"] = $"Click <a href='{url}'>here</a> to confirm your email.";
            
                return RedirectToAction("Login", "Account");
            }

            foreach (IdentityError err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
        }

        return View(model);
    }

    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
        {
            TempData["message"] = "Invalid confirmation request.";
            return View();
        }

        token = Uri.UnescapeDataString(token);

        var user = await _userManager.FindByIdAsync(userId);
    
        if (user == null)
        {
            TempData["message"] = "User not found.";
            return View();
        }

        var isValid = await _userManager.VerifyUserTokenAsync(user, 
            _userManager.Options.Tokens.EmailConfirmationTokenProvider, 
            "EmailConfirmation", token);

        Console.WriteLine($"Token Valid: {isValid}");
        if (!isValid)
        {
            TempData["message"] = "Token is invalid or expired.";
            return View();
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (result.Succeeded)
        {
            TempData["message"] = "Account has been confirmed.";
        }
        else
        {
            TempData["message"] = "Email confirmation failed.";
        }

        return View();
    }
}
