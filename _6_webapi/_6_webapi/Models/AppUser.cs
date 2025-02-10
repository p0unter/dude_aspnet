using Microsoft.AspNetCore.Identity;

namespace _6_webapi.Models;

public class AppUser : IdentityUser<int>
{
    public string FullName { get; set; } = string.Empty;
    public DateTime DateAdded { get; set; }
}