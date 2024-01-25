namespace Heimdall.Templates.DotNet.Microservice.Application.Telemetry;

using System.Diagnostics;

public static class Activities
{
    public static ActivitySource ApplicationActivitySource { get; } = new ActivitySource(Service.Name, Service.Version);
}