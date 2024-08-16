using AuthenticationApplication.Data;
using AuthenticationApplication.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default")));


builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{

    // User Settings
    // Kullanıcı adına izin verilern karakterler
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    // aynı mail adresi birden fazla kullanılamaz, mail uniq olmak zorundadır
    options.User.RequireUniqueEmail = true;

    // Password Settings
    options.Password.RequireDigit = true;           // En az bir rakam
    options.Password.RequiredLength = 6;            // En az 6 karakter
    options.Password.RequireLowercase = true;       // En az bir küçük harf
    options.Password.RequireUppercase = true;       // En az bir büyük harf
    options.Password.RequireNonAlphanumeric = true; // En az bir özel karakter
    // options.Password.RequiredUniqueChars = 1;       // Tekrar eden karakter sayısı (örn: aa, bb, cc gibi) 1 olmalıdır
}).AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Manage/account/login";
        options.AccessDeniedPath = "/Manage/account/accessdenied";
    });




var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.Run();
