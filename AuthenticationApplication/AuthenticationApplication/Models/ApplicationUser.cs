using Microsoft.AspNetCore.Identity;

namespace AuthenticationApplication.Models;

public class ApplicationUser : IdentityUser<int>
{
    public string? ApiKey { get; set; }
    public string? SecretKey { get; set; }
}

public class ApplicationRole : IdentityRole<int>
{
    public DateTime? ExpireDate { get; set; }
}