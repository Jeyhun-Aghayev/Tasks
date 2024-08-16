using Microsoft.AspNetCore.Identity;

namespace AuthencationLAB.Models;

public class AppUser:IdentityUser<int>
{
    public string? ApiKey { get; set; }
    public string? SecretKey { get; set; }
}
public class AppRole : IdentityRole<int>
{
    public DateTime? ExpireDate { get; set; }
}
