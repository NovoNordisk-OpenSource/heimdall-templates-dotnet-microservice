using BeHeroes.CodeOps.Abstractions.Data;
using BeHeroes.CodeOps.Abstractions.Repositories;
using BeHeroes.CodeOps.Abstractions.Strategies;
using BeHeroes.CodeOps.Infrastructure.EntityFramework;
using Confluent.Kafka;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Repositories;
using Heimdall.Templates.DotNet.Microservice.Domain.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Heimdall.Templates.DotNet.Microservice.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //Framework dependencies
            services.AddLogging();

            //Application dependencies
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //TODO: Debug new interface requirements
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddApplicationContext(configuration);
            services.AddRepositories();
            services.AddServices();
            services.AddStrategies();
            services.AddFacade();
        }

        private static void AddApplicationContext(this IServiceCollection services, IConfiguration configuration)
        {
            //TODO: Implement EF context & options
            // services.Configure<EntityContextOptions>(configuration);

            // services.AddDbContext<ApplicationContext>(options =>
            // {
            //     var serviceProvider = services.BuildServiceProvider();
            //     var dbContextOptions = serviceProvider.GetService<IOptions<EntityContextOptions>>();
            //     var callingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            //     var connectionString = dbContextOptions.Value.ConnectionStrings?.GetValue<string>(nameof(ApplicationContext));

            //     if (string.IsNullOrEmpty(connectionString))
            //     {
            //         throw new ApplicationFacadeException($"Could not find connection string with entry key: {nameof(ApplicationContext)}");
            //     }

            //     var dbOptions = options.UseNpgsql(connectionString,
            //         sqliteOptions =>
            //         {
            //             sqliteOptions.MigrationsAssembly(callingAssemblyName);
            //             sqliteOptions.MigrationsHistoryTable(callingAssemblyName + "_MigrationHistory");

            //         }).Options;

            //     using var context = new ApplicationContext(dbOptions, serviceProvider.GetService<IMediator>());

            //     if (dbContextOptions.Value.EnableAutoMigrations)
            //     {
            //         context.Database.Migrate();
            //     }
            // });

            // services.AddTransient<IUnitOfWork>(factory => factory.GetRequiredService<ApplicationContext>());
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            //services.AddTransient<IRepository<SampleRoot>, SampleRepository>();
            //services.AddTransient<ISampleRepository, SampleRepository>();
        }

        private static void AddServices(this IServiceCollection services)
        {
            //services.AddTransient<ISampleService, SampleService>();
        }

        private static void AddStrategies(this IServiceCollection services)
        {
            //TODO: Implement Kafka consumer strategy
            //services.AddTransient<IStrategy<ConsumeResult<string, string>>, AwsAccountEventConsumptionStrategy>();
        }

        private static void AddFacade(this IServiceCollection services)
        {
            services.AddTransient<IApplicationFacade, ApplicationFacade>();
        }
    }
}
