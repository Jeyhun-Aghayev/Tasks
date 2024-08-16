using AuthenticationApplication.Cryptography.PhyHelper;
using AuthenticationApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApplication.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Category> Category { get; set; }
    public DbSet<Tenant> Tenant { get; set; }
}
public class ApplicationDbContextFactory
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;
    private readonly ICryptographyService _cryptographyService;
    private readonly ApplicationDbContext _applicationDbContext;

    public ApplicationDbContextFactory(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, ICryptographyService cryptographyService, ApplicationDbContext applicationDbContext)
    {
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
        _cryptographyService = cryptographyService;
        _applicationDbContext = applicationDbContext;
    }
    public ApplicationDbContext CreateContext()
    {
        var tenentId = _httpContextAccessor.HttpContext!.Response.Headers["TenentId"].FirstOrDefault();
        var user = _httpContextAccessor.HttpContext.User;
       
        string connectionString = default(string);
        if (string.IsNullOrWhiteSpace(tenentId))
        {
            connectionString = _configuration.GetConnectionString("default");
        }
        else
        {
            var tenant = _applicationDbContext.Tenant.FirstOrDefault(x=>x.Id == int.Parse(tenentId));
            connectionString = _cryptographyService.Decrypt(tenant.ConnectionString, tenant.TenancyName);
        }
        return default;
    }
}
