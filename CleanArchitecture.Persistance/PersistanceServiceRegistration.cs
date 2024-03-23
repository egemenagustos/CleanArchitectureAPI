using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Persistance.Contexts;
using CleanArchitecture.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<BaseDbContext>(options =>
            //{
            //    options.UseInMemoryDatabase("cleanArchitecture");
            //});

            services.AddDbContext<BaseDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString:Database"]);
            });

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IFuelRepository, FuelRepository>();
            services.AddScoped<ITransmissionRepository, TransmissionRepository>();

            return services;
        }
    }
}
