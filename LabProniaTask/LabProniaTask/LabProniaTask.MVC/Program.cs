using LabProniaTask.MVC.Repository.Abstractions;
using LabProniaTask.MVC.Repository.Concretes;
using LabProniaTask.MVC.Service.Abstractions;
using LabProniaTask.MVC.Service.Concretes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppdbContext>(option=>
option.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IReadRepository<SliderItem>, ReadRepository<SliderItem>>();
builder.Services.AddScoped<ISliderItemService, SliderItemService>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
