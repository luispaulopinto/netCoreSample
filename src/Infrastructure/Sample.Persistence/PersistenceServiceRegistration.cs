using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sample.Application.Contracts.Persistence;
using Sample.Domain.Interfaces;
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

            SetClientChainInterceptor setClientChainInterceptor = new();

            services.AddDbContext<SampleDbContext>(options =>
                options
                    .UseNpgsql(configuration.GetConnectionString("SampleConnectionString"))
                    // .AddInterceptors(setClientChainInterceptor)
                    // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    // .LogTo(s => System.Diagnostics.Debug.WriteLine(s), LogLevel.Information)
                    .EnableDetailedErrors(isDebugMode)
                    .EnableSensitiveDataLogging(isDebugMode)
            );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            // services.AddScoped<ICategoryRepository, CategoryRepository>();
            // services.AddScoped<IEventRepository, EventRepository>();
            // services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            return services;
        }

        public class SetClientChainInterceptor : IMaterializationInterceptor
        {
            public object InitializedInstance(
                MaterializationInterceptionData materializationData,
                object instance
            )
            {
                if (instance is IAggregateRoot) { }

                return instance;
            }
        }
    }
}
