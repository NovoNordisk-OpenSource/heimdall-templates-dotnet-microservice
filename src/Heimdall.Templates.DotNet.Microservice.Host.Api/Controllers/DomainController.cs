namespace Heimdall.Templates.DotNet.Microservice.Host.Api.Controllers;

using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Application;
using Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;
using Heimdall.Templates.DotNet.Microservice.Application.Telemetry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

/// <summary>
/// Represents a controller for managing domain entities.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DomainController : ControllerBase
{
    private readonly System.Diagnostics.Metrics.Counter<int> _requestCounter = Metrics.RequestMeter.CreateCounter<int>("request.counter", description: "Counts the number of requests serviced by the controller");

    private readonly IApplicationFacade _facade;

    private readonly ILogger<DomainController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainController"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="facade">The application facade instance.</param>
    public DomainController(ILogger<DomainController> logger, IApplicationFacade facade){
        _logger = logger;
        _facade = facade;
    } 

    /// <summary>
    /// Gets all domain entities asynchronously.
    /// </summary>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities.</returns>
    [HttpGet()]
    public async Task<IEnumerable<DomainEntity>> GetDomainEntitiesAsync(CancellationToken ct = default)
    {
        // Initialize custom activity
        using var activity = Activities.ApplicationActivitySource.StartActivity(string.Format("{0}.{1}", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name));

        // Increment custom metric
        _requestCounter.Add(1);

        //Initialize command to get all domain entities
        var command = new GetDomainEntitiesCommand();

        // Dispatch command to application facade
        var entities = await _facade.Execute(command, ct);
        var entityCount = entities.Count();

        // Add a tag to the custom activity containing a entity count (replace Hello World!, even thou we love it)
        activity?.SetTag(nameof(entityCount), entityCount);

        // Log the number of entities returned
        _logger.LogDomainEntityReturnCount(entityCount);

        return entities;
    }
}