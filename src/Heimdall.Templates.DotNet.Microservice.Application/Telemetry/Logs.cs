namespace Heimdall.Templates.DotNet.Microservice.Application.Telemetry;

using Microsoft.Extensions.Logging;

public static partial class Logs
{
    [LoggerMessage(LogLevel.Information, "Starting the application with process id: {processId}.")]
    public static partial void LogStarting(this ILogger logger, int processId);

    [LoggerMessage(LogLevel.Information, "DomainEntityReturnCount: `{count}` entities returned to client.")]
    public static partial void LogDomainEntityReturnCount(this ILogger logger, int count);
}