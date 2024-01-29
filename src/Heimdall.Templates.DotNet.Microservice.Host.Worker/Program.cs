// Create application builder
var builder = Host.CreateApplicationBuilder(args);

// Register infrastructure dependencies
builder.Services.AddInfrastructure(builder.Configuration);
// TODO: Move this to the Kafka package in CodeOps
builder.Services.AddTransient<KafkaConsumerService>();

// Register services
builder.Services.AddHostedService<InitializedWrapperService<KafkaConsumerService>>();

// Setup health checks
builder.Services.AddSingleton<InitializedHealthCheck>();
builder.Services.AddHealthChecks().AddCheck<InitializedHealthCheck>("Initialized", tags: ["readiness"]);

// Build host
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