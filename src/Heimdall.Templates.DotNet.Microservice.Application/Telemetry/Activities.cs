using System.Diagnostics;

namespace Heimdall.Templates.DotNet.Microservice.Application.Telemetry
{
    public static class Activities
    {
        public static ActivitySource ApplicationActivitySource { get; } = new ActivitySource(Service.Name, Service.Version);
    }
}