namespace Heimdall.Templates.DotNet.Microservice.Application.Telemetry;

using System.Diagnostics;

/// <summary>
/// Represents the activity sources for the application.
/// </summary>
public static class Activities
{
    public static ActivitySource ApplicationActivitySource { get; } = new ActivitySource(Service.Name, Service.Version);
}