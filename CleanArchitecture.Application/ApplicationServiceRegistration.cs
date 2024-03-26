using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Serilog;
using Core.CrossCuttingConcerns.Serilog.Loggers;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
                configuration.AddOpenBehavior(typeof(TranscationScopeBehavior<,>));
                configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
                configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
                configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddSingleton<LoggerServiceBase, FileLogger>();
            services.AddSingleton<LoggerServiceBase, MssqlLogger>();

            return services;
        }

        public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly, Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCyle = null)
        {
            var types = assembly.GetTypes().Where(x => x.IsSubclassOf(type) && type != x).ToList();
            foreach(var item in types)            
                if (addWithLifeCyle == null)
                    services.AddScoped(item);
                else
                    addWithLifeCyle(services, type);
            return services;
        }
    }
}
