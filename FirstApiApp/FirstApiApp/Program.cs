using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FirstApiApp.Data;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.Routing;

namespace FirstApiApp;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<FirstApiAppContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("FirstApiAppContext") ?? throw new InvalidOperationException("Connection string 'FirstApiAppContext' not found.")));

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddRateLimiter(option =>
        {
            option.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(
                httpContext =>RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: httpContext.User.Identity.Name ?? httpContext.Request.Path.ToString(),
                    factory: Partition => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 10, //maxsimum izin sayisi
                        Window = TimeSpan.FromMinutes(1),
                        QueueProcessingOrder = QueueProcessingOrder.OldestFirst, //ilk request ilk islenir fiyerleri sirayla kuyruga girer
                        QueueLimit = 2 //kuyruk siniri
                    })
                );
        });
        builder.Services.AddRateLimiter(option =>
        {
            option.AddFixedWindowLimiter("codeacademy", opt =>
            {
                opt.PermitLimit = 10;
                opt.Window = TimeSpan.FromMinutes(1);
            });
        });
        builder.Services.AddRateLimiter(option =>
        {
            option.AddFixedWindowLimiter("Xacademy", opt =>
            {
                opt.PermitLimit = 5;
                opt.Window = TimeSpan.FromSeconds(20);
            });
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseRateLimiter();

        //app.MapControllers();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers().RequireRateLimiting("codeacademy").WithMetadata(new RouteNameMetadata("v1"));
            endpoints.MapControllers().RequireRateLimiting("Xacademy").WithMetadata(new RouteNameMetadata("v2"));
        });
        app.Run();
    }
}
