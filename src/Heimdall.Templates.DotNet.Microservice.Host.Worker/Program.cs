using BeHeroes.CodeOps.Infrastructure.Kafka;
using Heimdall.Templates.Dotnet.Microservice.Infrastructure;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHostedService<KafkaConsumerService>();

var host = builder.Build();
var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();

using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource(executingAssembly.FullName)
    .ConfigureResource(resource =>
        resource.AddService(
          serviceName: executingAssembly.FullName,
          serviceVersion: executingAssembly.ManifestModule.ModuleVersionId.ToString()))
    .AddConsoleExporter()
    .Build();

host.Run();
