namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.OpenTelemetry;

public static class Extensions
{
    public static TracerProviderBuilder ConfigureTraceExporter(this TracerProviderBuilder builder, string? otlpEndpoint)
    {
        if (!string.IsNullOrEmpty(otlpEndpoint))
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
                    )
                    {
                        Timeout = TimeSpan.FromMilliseconds(otlpOptions.TimeoutMilliseconds)
                    };

                    return client;
                };
            });
        else
            builder.AddConsoleExporter();

        return builder;
    }

    public static MeterProviderBuilder ConfigureMeterExporter(this MeterProviderBuilder builder, string? otlpEndpoint)
    {
        if (!string.IsNullOrEmpty(otlpEndpoint))
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
                    )
                    {
                        Timeout = TimeSpan.FromMilliseconds(otlpOptions.TimeoutMilliseconds)
                    };

                    return client;
                };
            });
        else
            builder.AddConsoleExporter();

        return builder;
    }

    public static OpenTelemetryLoggerOptions ConfigureLoggerExporter(this OpenTelemetryLoggerOptions options, string? otlpEndpoint)
    {
        if (!string.IsNullOrEmpty(otlpEndpoint))
            options.AddOtlpExporter(otlpOptions =>
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
                    )
                    {
                        Timeout = TimeSpan.FromMilliseconds(otlpOptions.TimeoutMilliseconds)
                    };

                    return client;
                };
            });
        else
            options.AddConsoleExporter();

        return options;
    }
} 
