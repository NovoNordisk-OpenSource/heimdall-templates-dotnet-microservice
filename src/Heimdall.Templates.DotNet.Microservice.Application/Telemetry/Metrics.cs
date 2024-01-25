namespace Heimdall.Templates.DotNet.Microservice.Application.Telemetry;

using System.Diagnostics.Metrics;

public static class Metrics
{
    public static Meter RequestMeter { get; } = new Meter("Application.Request", "1.0.0");

    public static Meter EventMeter { get; } = new Meter("Application.Event", "1.0.0");
}