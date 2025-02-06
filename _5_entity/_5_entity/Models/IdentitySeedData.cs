using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _5_entity.Models;

public class IdentitySeedData
{
    private const string AdminUserName = "admin";
    private const string AdminPassword = "Admin_123";

    public static async void IdentityTestUser(IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<IdentityContext>();
        
        if (context.Database.GetAppliedMigrations().Any())
        {
            context.Database.Migrate();
        }

        var userManager = app.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<UserManager<AppUser>>();
        
        var user = await userManager.FindByNameAsync(AdminUserName);

        if (user == null)
        {
            user = new AppUser()
            {
                FullName = "Pounter",
                Email = "admin@gmail.com",
                PhoneNumber = "0123456789"
            };
            
            await userManager.CreateAsync(user, AdminPassword);
        }
    }
}