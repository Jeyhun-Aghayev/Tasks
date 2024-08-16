using AuthenticationApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApplication.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}
