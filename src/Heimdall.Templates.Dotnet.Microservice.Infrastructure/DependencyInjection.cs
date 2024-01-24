using BeHeroes.CodeOps.Abstractions.Data;
using BeHeroes.CodeOps.Abstractions.Repositories;
using BeHeroes.CodeOps.Abstractions.Strategies;
using BeHeroes.CodeOps.Infrastructure.Kafka;
using BeHeroes.CodeOps.Security.Policies;
using BeHeroes.CodeOps.Infrastructure.EntityFramework;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Repositories;
using Heimdall.Templates.DotNet.Microservice.Domain.Services;
using Heimdall.Templates.Dotnet.Microservice.Infrastructure.Kafka.Strategies;
using Heimdall.Templates.Dotnet.Microservice.Infrastructure.EntityFramework;
using Heimdall.Templates.Dotnet.Microservice.Infrastructure.EntityFramework.Repositories;
using Heimdall.Templates.DotNet.Microservice.Application;
using Confluent.Kafka;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {            
            //Upstream dependencies
            services.AddApplication(configuration);
            services.AddKafka(configuration);
            services.AddSecurityPolicies();

            //Application dependencies
            services.AddApplicationContext(configuration);
            services.AddRepositories();
            services.AddStrategies();
        }

        private static void AddApplicationContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EntityContextOptions>(configuration);

            services.AddDbContext<ApplicationContext>(options =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var dbContextOptions = serviceProvider.GetService<IOptions<EntityContextOptions>>();
                var callingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                var connectionString = dbContextOptions?.Value?.ConnectionStrings?.GetValue<string>(nameof(ApplicationContext));

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ApplicationFacadeException($"Could not find connection string with entry key: {nameof(ApplicationContext)}");
                }

                var dbOptions = options.UseNpgsql(connectionString,
                    sqliteOptions =>
                    {
                        sqliteOptions.MigrationsAssembly(callingAssemblyName);
                        sqliteOptions.MigrationsHistoryTable(callingAssemblyName + "_MigrationHistory");

                    }).Options;

                #pragma warning disable CS8604
                using var context = new ApplicationContext(dbOptions, serviceProvider?.GetService<IMediator>());                
                #pragma warning disable CS8604

                if (dbContextOptions?.Value?.EnableAutoMigrations == true)
                {
                    context.Database.Migrate();
                }
            });

            services.AddTransient<IUnitOfWork>(factory => factory.GetRequiredService<ApplicationContext>());
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<DomainEntity>, DomainEntityRepository>();
            services.AddTransient<IDomainEntityRepository, DomainEntityRepository>();
        }

        private static void AddStrategies(this IServiceCollection services)
        {
            services.AddTransient<IStrategy<ConsumeResult<string, string>>, GenericIntegrationEventConsumptionStrategy>();
        }
    }
}
