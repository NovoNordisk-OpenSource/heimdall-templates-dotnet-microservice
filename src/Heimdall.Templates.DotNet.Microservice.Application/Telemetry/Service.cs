using System.Diagnostics;
using System.Reflection;

namespace Heimdall.Templates.DotNet.Microservice.Application.Telemetry
{
    public static class Service
    {
        public static string Name { get; } = nameof(Service);

        public static string Version { get; } = typeof(Service).Assembly.ManifestModule.ModuleVersionId.ToString();
    }
}