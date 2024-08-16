using AuthencationLAB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthencationLAB;

public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}
