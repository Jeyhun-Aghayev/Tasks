using HangFireApplication.MqServices;
using MassTransit;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace HangFireApplication.Configuration;

public static class RabbitMqConfiguration
{
    public static void ConfigureRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        var rabbitMqConfig = configuration
        .GetSection("RabbitMq")
        .Get<RabbitMqConfig>();

        //services.AddSingleton(rabbitMqConfig);

        services.AddMassTransit(x =>
        {
            //x.AddConsumers(consumerAssemblyMarkerType.Assembly);

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqConfig.Host, h =>
                {
                    h.Username(rabbitMqConfig.Username);
                    h.Password(rabbitMqConfig.Password);
                });

                //cfg.ReceiveEndpoint(rabbitMqConfig.ExchangeName, e =>
                //{
                // e.ConfigureConsumers(context);
                //});
            });

        });

        services.AddHostedService<RabbitMqHostedService>();
    }
}


public class RabbitMqConfig
{
    public string Host { get; set; }
    public int Port { get; set; } = 5672; // varsayılan port
    public string Username { get; set; } // default username -> guest


    public string Password { get; set; } // default password -> guest
    public string VirtualHost { get; set; } // -> "/"
}

