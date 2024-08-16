using AuthencationLAB;
using AuthencationLAB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    // User Settings
    // Kullan?c? ad?na izin verilern karakterler
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    // ayn? mail adresi birden fazla kullan?lamaz, mail uniq olmak zorundad?r
    options.User.RequireUniqueEmail = true;

    // Password Settings
    options.Password.RequireDigit = true; // En az bir rakam
    options.Password.RequiredLength = 6; // En az 6 karakter
    options.Password.RequireLowercase = true; // En az bir küçük harf
    options.Password.RequireUppercase = true; // En az bir büyük harf
    options.Password.RequireNonAlphanumeric = true; // En az bir özel karakter
                                                    // options.Password.RequiredUniqueChars = 1; // Tekrar eden karakter say?s? (örn: aa, bb, cc gibi) 1 olmal?d?r
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
