using SignalRApplication;
using SignalRApplication.Repositories;
using SignalRApplication.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSignalR();
builder.Services.AddScoped<IProductRepository, ProductService>();
builder.Services.AddScoped<ICategoryRepository, CategoryService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapHub<SignalRServer>("/signalRServer");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



/*
 SELECT is_broker_enabled FROM sys.databases WHERE name =  'SignalRServerDb'
ALTER DATABASE SignalRServerDb SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE
 */