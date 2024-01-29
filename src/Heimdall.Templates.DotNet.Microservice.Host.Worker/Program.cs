// Create application builder
var builder = Host.CreateApplicationBuilder(args);

// Fetch OTLP endpoint from configuration.
var otlpEndpoint = builder.Configuration["OTLP_ENDPOINT_URL"];

// Register infrastructure dependencies
builder.Services.AddInfrastructure(builder.Configuration);

// Register services
builder.Services.AddHostedService<InitializedWrapperService<KafkaConsumerService>>();

// Setup health checks
builder.Services.AddSingleton<InitializedHealthCheck>();
builder.Services.AddHealthChecks().AddCheck<InitializedHealthCheck>("Initialized", tags: ["readiness"]);

// Add OpenTelemetry dependencies
builder.Services.AddOpenTelemetry()
    // Configure OpenTelemetry Traces
    .WithTracing(builder =>
    {
        builder.AddSource(Service.Name)
            .ConfigureResource(resource =>
                resource.AddService(
                    Service.Name,
                    serviceVersion: Service.Version))
            .ConfigureTraceExporter(otlpEndpoint);
    })
    // Configure OpenTelemetry Metrics
    .WithMetrics(builder =>
    {
        builder.AddMeter(Metrics.RequestMeter.Name)
            .AddMeter(Metrics.EventMeter.Name)
            .ConfigureMeterExporter(otlpEndpoint);
    });

// Configure OpenTelemetry Logs
builder.Logging.AddOpenTelemetry(logging =>
{
    logging.IncludeScopes = true;

    var resourceBuilder = ResourceBuilder
        .CreateDefault()
        .AddService(Service.Name);

    logging.SetResourceBuilder(resourceBuilder).ConfigureLoggerExporter(otlpEndpoint);
});

// Build host
var host = builder.Build();

host.Run();