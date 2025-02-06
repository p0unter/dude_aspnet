using _5_entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace _5_entity.TagHelpers;

[HtmlTargetElement("td", Attributes = "asp-role-users")]
public class RoleUsersTagHelper : TagHelper
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;

    public RoleUsersTagHelper(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    [HtmlAttributeName("asp-role-users")] 
    public string RoleId { get; set; } = null!;

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var userNames = new List<string>();
        var role = await _roleManager.FindByIdAsync(RoleId);

        if (role != null && !string.IsNullOrEmpty(role.Name))
        {
            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userNames.Add($"{user.FullName}({user.UserName})" ?? "");
                }
            }
            // output.Content.SetContent(userNames.Count == 0 ? "User not found." : string.Join(", ", userNames));
            output.Content.SetHtmlContent(userNames.Count == 0 ? "User not found." : string.Join(", ", SetHtml(userNames)));
        }
    }

    private string SetHtml(List<string> userNames)
    {
        var html = "<ul>";
        foreach (var item in userNames)
        {
            html += $"<li>{item}</li>";
        }
        html += "</ul>";
        return html;
    }
}