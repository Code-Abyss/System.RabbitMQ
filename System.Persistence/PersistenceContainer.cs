using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Application.Contracts;
using System.Persistence.Repositories;

namespace System.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceSerice(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<SystemDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

            service.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            service.AddScoped(typeof(IOrderAsyncRepository), typeof(OrderRepository));
            return service;
        }
    }
}
