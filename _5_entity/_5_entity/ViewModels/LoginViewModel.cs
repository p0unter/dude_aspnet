using System.ComponentModel.DataAnnotations;

namespace _5_entity.ViewModels;

public class LoginViewModel
{
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; } = true;
}