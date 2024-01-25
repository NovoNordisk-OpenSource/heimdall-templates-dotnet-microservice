namespace Heimdall.Templates.DotNet.Microservice.Application;

using BeHeroes.CodeOps.Abstractions.Data;
using BeHeroes.CodeOps.Abstractions.Repositories;
using BeHeroes.CodeOps.Abstractions.Strategies;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Repositories;
using Heimdall.Templates.DotNet.Microservice.Domain.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

/// <summary>
/// Provides extension methods to configure dependency injection for the application layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Configures the application layer dependencies.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the dependencies to.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> instance.</param>
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        //Framework dependencies
        services.AddLogging();

        //Upstream dependencies            
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));    

        //Application dependencies        
        services.AddFacade();
        services.AddServices();
    }

    private static void AddFacade(this IServiceCollection services)
    {
        services.AddTransient<IApplicationFacade, ApplicationFacade>();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IDomainService, DomainService>();
    }
}