using Microsoft.Extensions.DependencyInjection;
using System.Services.RabbitMQ;
using System.Services.RabbitMQ.Produser;

namespace System.Services
{
    public static class ServicesContainer
    {
        public static IServiceCollection AddServicesServices(this IServiceCollection services)
        {
            services.AddScoped<IMessageProducer, RabbitMQProducer>();
            return services;
        }
    }


}
