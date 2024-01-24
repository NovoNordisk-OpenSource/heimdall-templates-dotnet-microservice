using System.Diagnostics;
using System.Reflection;

namespace Heimdall.Templates.DotNet.Microservice.Application.Telemetry
{
    public static class Source
    {
        public static string ServiceName { get; } = Assembly.GetExecutingAssembly().FullName ?? Process.GetCurrentProcess().ProcessName;

        public static string ServiceVersion { get; } = Assembly.GetExecutingAssembly().ManifestModule.ModuleVersionId.ToString();
    }
}