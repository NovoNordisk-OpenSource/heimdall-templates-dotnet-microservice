/// <summary>
/// Represents the available options for authorization in OpenTelemetry.
/// </summary>
namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.OpenTelemetry;

public enum AuthorizationOptions
{
    NoAuth,
    ServicePrincipal,
    SystemAssignedIdentity,
    UserAssignedIdentity
}