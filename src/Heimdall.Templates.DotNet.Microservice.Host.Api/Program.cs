

var builder = WebApplication.CreateBuilder(args);

var otlpEndpoint = builder.Configuration["OTLP_ENDPOINT_URL"];
var otlpTenantId = builder.Configuration.GetSection("AzureAD")["TenantId"];

// Add required services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration)
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddMicrosoftGraph(builder.Configuration.GetSection("GraphBeta"))
    .AddInMemoryTokenCaches();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen();

// Configure OpenTelemetry Traces, Metrics & Logs
builder.Services.AddOpenTelemetry()
    .WithTracing(builder =>
    {
        builder.AddSource(Service.Name)
            .ConfigureResource(resource =>
                resource.AddService(
                    Service.Name,
                    serviceVersion: Service.Version))
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation();

        if (otlpEndpoint != null)
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
        else
            builder.AddConsoleExporter();
    })
    .WithMetrics(builder =>
    {
        builder.AddMeter(Metrics.RequestMeter.Name)
            .AddMeter("Microsoft.AspNetCore.Hosting")
            .AddMeter("Microsoft.AspNetCore.Server.Kestrel");

        if (otlpEndpoint != null)
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
        else
            builder.AddConsoleExporter();
    });

builder.Logging.AddOpenTelemetry(logging =>
{
    logging.IncludeScopes = true;

    var resourceBuilder = ResourceBuilder
        .CreateDefault()
        .AddService(Service.Name);

    if (otlpEndpoint != null)
        logging.SetResourceBuilder(resourceBuilder).AddOtlpExporter(otlpOptions =>
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
    else
        logging.SetResourceBuilder(resourceBuilder).AddConsoleExporter();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

// Add health checks
app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

// Map controllers routes.
app.MapControllers();

// Log the process id.
app.Logger.LogStarting(Process.GetCurrentProcess().Id);

// Start the application.
app.Run();