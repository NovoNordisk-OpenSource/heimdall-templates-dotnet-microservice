namespace Heimdall.Templates.DotNet.Microservice.Application.Telemetry;

using System.Diagnostics;
using System.Reflection;

/// <summary>
/// Represents a service for telemetry purposes.
/// </summary>
public static class Service
{
    /// <summary>
    /// Gets the name of the service.
    /// </summary>
    public static string Name { get; } = typeof(Service).ToString();

    /// <summary>
    /// Gets the version of the service.
    /// </summary>
    public static string Version { get; } = typeof(Service).Assembly.ManifestModule.ModuleVersionId.ToString();
}