using BeHeroes.CodeOps.Infrastructure.Kafka;
using Heimdall.Templates.DotNet.Microservice.Application.Telemetry;
using Heimdall.Templates.Dotnet.Microservice.Infrastructure;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHostedService<KafkaConsumerService>();

var host = builder.Build();

// TODO: Configure OpenTelemetry Traces, Metrics & Logs
using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource(Service.Name)
    .ConfigureResource(resource =>
        resource.AddService(
          serviceName: Service.Name,
          serviceVersion: Service.Version))
    .AddConsoleExporter()
    .Build();

host.Run();
