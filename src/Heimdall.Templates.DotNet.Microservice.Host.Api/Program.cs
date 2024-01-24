using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Application;
using Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;
using Heimdall.Templates.DotNet.Microservice.Application.Telemetry;
using Heimdall.Templates.Dotnet.Microservice.Infrastructure;
using Heimdall.Templates.Dotnet.Microservice.Infrastructure.OpenTelemetry;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

//TODO: Setup configuration files and configuration loaders (environment, json, secrets, vault)
var otlpEndpoint = builder.Configuration["OTLP_ENDPOINT_URL"];
var otlpTenantId = builder.Configuration["OTLP_TENANT_ID"];

// Add required services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure OpenTelemetry
builder.Services.AddOpenTelemetry()
                .WithTracing(builder =>
                {

                    builder.AddSource(Source.ServiceName)
                            .ConfigureResource(resource =>
                                resource.AddService(
                                    serviceName: Source.ServiceName,
                                    serviceVersion: Source.ServiceVersion))
                            .AddAspNetCoreInstrumentation()
                            .AddHttpClientInstrumentation();

                    if (otlpEndpoint != null)
                    {
                        builder.AddOtlpExporter(otlpOptions =>
                        {
                            otlpOptions.Endpoint = new Uri(otlpEndpoint);
                            otlpOptions.HttpClientFactory = () =>
                            {
                                var innerHandler = new HttpClientHandler();
                                var client = new HttpClient(
                                    new AuthorizationHeaderHandler(
                                        innerHandler,
                                        AuthorizationEnvironmentOptions.NoAuth
                                    )
                                );
                                
                                client.Timeout = TimeSpan.FromMilliseconds(
                                    otlpOptions.TimeoutMilliseconds
                                );

                                return client;
                            };
                        });
                    }
                    else
                    {
                        builder.AddConsoleExporter();
                    }
                })
                .WithMetrics(builder =>
                {
                    //TODO: Finish configuration of metrics builder
                    builder.AddMeter(Metrics.RequestMeter.Name)
                           .AddMeter("Microsoft.AspNetCore.Hosting")
                           .AddMeter("Microsoft.AspNetCore.Server.Kestrel");                    
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//TODO: Add HTTPS support
//app.UseHttpsRedirection();

//TODO: Enable with custom metrics
//var requestCounter = Metrics.RequestMeter.CreateCounter<int>("request.count", description: "Counts the number of requests");

//TODO: Inject IApplicationFacade
async Task<IEnumerable<DomainEntity>> GetEntities(ILogger<Program> logger, IApplicationFacade facade, CancellationToken ct = default)
{
    // Initialize custom activity
    using var activity = Activities.ApplicationActivitySource.StartActivity("Host.Api.GetEntities");

    //TODO: Enable with custom metrics
    //requestCounter.Add(1);

    //Initialize command to get all domain entities
    var command = new GetDomainEntitiesCommand();

    //TODO: Enable once connection string is wired into configuration
    // Dispatch command to application facade
    //var entities = await facade.Execute(command, ct);
    var entities = new List<DomainEntity>();

    // Add a tag to the custom activity containing a entity count (replace Hello World!, even thou we love it)
    activity?.SetTag("entityCount", entities.Count());

    return entities;
}

app.MapGet("/entities", GetEntities)
.WithName("GetEntities")
.WithOpenApi();

app.Run();
