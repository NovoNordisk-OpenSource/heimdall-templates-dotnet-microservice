namespace Heimdall.Templates.DotNet.Microservice.Application.Telemetry;

/// <summary>
///     Represents the metrics for the application.
/// </summary>
public static class Metrics
{
    public static Meter RequestMeter { get; } = new("application.requests", "1.0.0");

    public static Meter EventMeter { get; } = new("application.events", "1.0.0");
}