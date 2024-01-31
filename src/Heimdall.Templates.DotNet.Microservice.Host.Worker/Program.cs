// Create application builder
var builder = Host.CreateApplicationBuilder(args);

// Fetch OTLP endpoint from configuration.
var otlpEndpoint = builder.Configuration["OTLP_ENDPOINT_URL"];

// Fetch Microsoft Identity options from configuration.
var microsoftIdentityOptions = builder.Configuration.GetSection("AzureAd").Get<MicrosoftIdentityOptions>() ?? new MicrosoftIdentityOptions();

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
            .ConfigureTraceExporter(otlpEndpoint, microsoftIdentityOptions);
    })
    // Configure OpenTelemetry Metrics
    .WithMetrics(builder =>
    {
        builder.AddMeter(Metrics.RequestMeter.Name)
            .AddMeter(Metrics.EventMeter.Name)
            .ConfigureMeterExporter(otlpEndpoint, microsoftIdentityOptions);
    });

// Configure OpenTelemetry Logs
builder.Logging.AddOpenTelemetry(logging =>
{
    logging.IncludeScopes = true;

    var resourceBuilder = ResourceBuilder
        .CreateDefault()
        .AddService(Service.Name);

    logging.SetResourceBuilder(resourceBuilder).ConfigureLoggerExporter(otlpEndpoint, microsoftIdentityOptions);
});

// Build application
var app = builder.Build();

// Get logger to log process id
var logger = app.Services.GetRequiredService<ILogger<Program>>();
       
// Log the process id.
logger.LogStarting(Environment.ProcessId);

// Start the application.
app.Run();