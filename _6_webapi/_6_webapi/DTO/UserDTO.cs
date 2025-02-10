using System.ComponentModel.DataAnnotations;

namespace _6_webapi.DTO;

public class UserDTO
{
    [Required]
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}