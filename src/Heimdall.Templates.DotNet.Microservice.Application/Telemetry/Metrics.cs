using System.Diagnostics.Metrics;

namespace Heimdall.Templates.DotNet.Microservice.Application.Telemetry
{
    public static class Metrics
    {
        public static Meter RequestMeter { get; } = new Meter("Application.Request", "1.0.0");
    }
}