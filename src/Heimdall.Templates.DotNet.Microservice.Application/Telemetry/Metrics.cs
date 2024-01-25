namespace Heimdall.Templates.DotNet.Microservice.Application.Telemetry;

using System.Diagnostics.Metrics;

/// <summary>
/// Represents the metrics for the application.
/// </summary>
public static class Metrics
{
    public static Meter RequestMeter { get; } = new Meter("application.requests", "1.0.0");

    public static Meter EventMeter { get; } = new Meter("application.events", "1.0.0");
}