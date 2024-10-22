using EscolaRabbitMQ.Data;
using EscolaRabbitMQ.Services;
using MassTransit;

namespace EscolaRabbitMQ.Infra
{
    public static class AppExtesionsProducer
    {
        public static void AddRegisterServices(this IServiceCollection services, IConfiguration builder)
        {
            services.AddSingleton<ILivrosServices, LivrosServices>();
            services.AddScoped<IMessagePublisher, MessagePublisher>();
            services.AddScoped<ILivroRepository, LivrosRepository>();

            services.AddMassTransit(bus =>
            {
                bus.SetKebabCaseEndpointNameFormatter();

                bus.AddConsumer<MessageConsumer>();

                bus.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(builder["MessageBroker:Host"]!), h =>
                    {
                        h.Username(builder["MessageBroker:Username"]!);
                        h.Password(builder["MessageBroker:Password"]!);
                    });

                    cfg.ConfigureEndpoints(context, new KebabCaseEndpointNameFormatter("dev", false));
                });
            });
        }
    }
}
