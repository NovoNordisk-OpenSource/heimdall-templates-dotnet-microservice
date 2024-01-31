namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.OpenTelemetry;
/// <summary>
/// Represents a message handler that adds an authorization header to outgoing HTTP requests for telemetry purposes.
/// </summary>
public class AuthorizationHeaderHandler(HttpMessageHandler innerHandler, MicrosoftIdentityOptions identityOptions, AuthorizationOptions options = AuthorizationOptions.ServicePrincipal) : DelegatingHandler(innerHandler)
{
    private static readonly TimeSpan MinimumValidityPeriod = TimeSpan.FromMinutes(2);

    private AuthenticationResult? _bearerTelemetryAuthenticationResult = null;

    private MicrosoftIdentityOptions _identityOptions = identityOptions;

    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
    {       
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        request.Headers.Authorization = new AuthenticationHeaderValue(
            Constants.Bearer,
            GetAccessToken(Constants.Bearer)
        );

        return base.Send(request, cancellationToken);
    }

    private string? GetAccessToken(string tokenType)
    {
        string scope;

        switch (tokenType)
        {
            case Constants.Bearer:
                //TODO: Do we really need this scope or was this only for SystemAssignedIdentityWithCertificate?
                scope = Environment.GetEnvironmentVariable("OTLP_CLIENT_ID") ?? throw new ArgumentNullException($"OTLP_CLIENT_ID is null.");

                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(tokenType), tokenType, null);
        }

        var authenticationResult = tokenType switch
        {
            Constants.Bearer => _bearerTelemetryAuthenticationResult,
            _ => throw new ArgumentOutOfRangeException(nameof(tokenType), tokenType, null)
        };

        bool tokenExpiredOrAboutToExpire;

        if (authenticationResult != null)
            tokenExpiredOrAboutToExpire = authenticationResult?.ExpiresOn < DateTimeOffset.UtcNow + MinimumValidityPeriod;
        else
            tokenExpiredOrAboutToExpire = true;

        if (tokenExpiredOrAboutToExpire)
        {
            authenticationResult = GetAuthenticationResultAsync(_identityOptions, options, scope).Result;
        }

        if (authenticationResult == null)
        {
            return "NoAuthNDemo";
        }

        _bearerTelemetryAuthenticationResult = tokenType switch
        {
            Constants.Bearer => authenticationResult,
            _ => throw new ArgumentOutOfRangeException(nameof(tokenType), tokenType, null),
        };

        return authenticationResult?.AccessToken;
    }

    private static async Task<AuthenticationResult?> GetAuthenticationResultAsync(MicrosoftIdentityOptions identityOptions, AuthorizationOptions options, string scope)
    {
        var clientId = identityOptions.ClientId;
        var clientSecret = identityOptions.ClientSecret;
        var tenantId = identityOptions.TenantId;
        var uamiClientId = identityOptions.UserAssignedManagedIdentityClientId;

        IConfidentialClientApplication confidentialClientApplication;
        IManagedIdentityApplication managedIdApplication;
        AuthenticationResult? authenticationResult;

        switch (options)
        {
            case AuthorizationOptions.ServicePrincipal:
                if (clientId == null || clientSecret == null || tenantId == null)
                    throw new ArgumentNullException(
                        $"Identity options {identityOptions.ClientId}, {identityOptions.ClientSecret}, or {identityOptions.TenantId} is null."
                    );

                confidentialClientApplication = ConfidentialClientApplicationBuilder
                    .Create(clientId)
                    .WithClientSecret(clientSecret)
                    .WithAuthority($"https://login.microsoftonline.com/{tenantId}")
                    .WithExperimentalFeatures()
                    .Build();

                authenticationResult = await confidentialClientApplication
                    .AcquireTokenForClient(new[] { $"{scope}/.default" })
                    .ExecuteAsync()
                    .ConfigureAwait(false);

                break;

            case AuthorizationOptions.SystemAssignedIdentity:
                managedIdApplication = ManagedIdentityApplicationBuilder
                    .Create(ManagedIdentityId.SystemAssigned)
                    // Azure Container Apps does not work without this
                    .WithExperimentalFeatures()
                    .Build();

                authenticationResult = await managedIdApplication
                    .AcquireTokenForManagedIdentity(scope)
                    .ExecuteAsync()
                    .ConfigureAwait(false);

                break;

            case AuthorizationOptions.UserAssignedIdentity:
                if (uamiClientId == null)
                    throw new ArgumentNullException(
                        $"Identity option {identityOptions.UserAssignedManagedIdentityClientId} is null."
                    );

                managedIdApplication = ManagedIdentityApplicationBuilder
                    .Create(ManagedIdentityId.WithUserAssignedResourceId(uamiClientId))
                    // Azure Container Apps does not work without this
                    .WithExperimentalFeatures()
                    .Build();

                authenticationResult = await managedIdApplication
                    .AcquireTokenForManagedIdentity(scope)
                    .ExecuteAsync()
                    .ConfigureAwait(false);

                break;

            case AuthorizationOptions.NoAuth:
                authenticationResult = null;
                
                break;

            default:
                throw new ArgumentException($"Invalid AuthorizationEnvironmentOptions value {options}");
        }

        return authenticationResult;
    }
}