using Microsoft.AspNetCore.Identity;

namespace Backend.Blog.Model;

public class User : IdentityUser<Guid>
{
    //public List<Article> Articles { get; set; } = new List<Article>();
    public string? Info { get; set; }
    
    public string? Wechat { get; set; }

    public long JwtVersion { get; set; }

    public bool IsDeleted { get; set; } = false;
}