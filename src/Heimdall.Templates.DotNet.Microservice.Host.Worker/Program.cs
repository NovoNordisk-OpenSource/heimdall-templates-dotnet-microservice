var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHostedService<KafkaConsumerService>();

var host = builder.Build();

// TODO: Configure OpenTelemetry Traces, Metrics & Logs
using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource(Service.Name)
    .ConfigureResource(resource =>
        resource.AddService(
            Service.Name,
            serviceVersion: Service.Version))
    .AddConsoleExporter()
    .Build();

host.Run();