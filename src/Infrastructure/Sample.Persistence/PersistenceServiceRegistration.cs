using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Contracts.Persistence;
using Sample.Persistence.Repositories;

namespace Sample.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            bool isDebugMode = false;
#if (DEBUG)
            isDebugMode = true;
#endif

            services.AddDbContext<SampleDbContext>(options =>
                options
                    .UseNpgsql(configuration.GetConnectionString("SampleConnectionString"))
                    .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                    .EnableDetailedErrors(isDebugMode)
                    .EnableSensitiveDataLogging(isDebugMode)
            );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            return services;
        }
    }
}
