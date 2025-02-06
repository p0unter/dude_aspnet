using Microsoft.AspNetCore.Identity;

namespace _5_entity.Models;

public class AppUser : IdentityUser
{
    public string? FullName { get; set; }
}