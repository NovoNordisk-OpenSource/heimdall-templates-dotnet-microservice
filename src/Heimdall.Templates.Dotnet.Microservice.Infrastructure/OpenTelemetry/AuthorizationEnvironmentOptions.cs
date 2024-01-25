namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.OpenTelemetry;

//TODO: Review & refactor merged code
public enum AuthorizationEnvironmentOptions
{
    NoAuth,
    ServicePrincipal,
    SystemAssignedIdentity,
    SystemAssignedIdentityWithCertificate,
    UserAssignedIdentity
}