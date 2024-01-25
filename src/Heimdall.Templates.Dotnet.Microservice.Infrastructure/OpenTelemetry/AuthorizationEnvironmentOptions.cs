namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.OpenTelemetry;

using Microsoft.Identity.Client;
using System.Net.Http.Headers;

//TODO: Review & refactor merged code
public enum AuthorizationEnvironmentOptions
{
    NoAuth,
    ServicePrincipal,
    SystemAssignedIdentity,
    SystemAssignedIdentityWithCertificate,
    UserAssignedIdentity
}