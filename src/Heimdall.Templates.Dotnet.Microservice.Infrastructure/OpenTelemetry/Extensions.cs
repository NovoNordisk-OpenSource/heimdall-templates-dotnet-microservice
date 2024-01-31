namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.OpenTelemetry;

/// <summary>
/// Provides extension methods for configuring exporters in OpenTelemetry.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Configures the trace exporter in the TracerProviderBuilder.
    /// </summary>
    /// <param name="builder">The TracerProviderBuilder instance.</param>
    /// <param name="otlpEndpoint">The OTLP endpoint URL.</param>
    /// <returns>The TracerProviderBuilder instance.</returns>
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

    /// <summary>
    /// Configures the meter exporter in the MeterProviderBuilder.
    /// </summary>
    /// <param name="builder">The MeterProviderBuilder instance.</param>
    /// <param name="otlpEndpoint">The OTLP endpoint URL.</param>
    /// <returns>The MeterProviderBuilder instance.</returns>
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

    /// <summary>
    /// Configures the logger exporter in the OpenTelemetryLoggerOptions.
    /// </summary>
    /// <param name="options">The OpenTelemetryLoggerOptions instance.</param>
    /// <param name="otlpEndpoint">The OTLP endpoint URL.</param>
    /// <returns>The OpenTelemetryLoggerOptions instance.</returns>
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
