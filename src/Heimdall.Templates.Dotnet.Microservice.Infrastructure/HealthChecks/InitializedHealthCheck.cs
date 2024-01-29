namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.HealthChecks;

public sealed class InitializedHealthCheck : IHealthCheck
{
    private volatile bool _isInitialized;

    public bool Initialized
    {
        get => _isInitialized;
        set => _isInitialized = value;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        if (Initialized)
        {
            return Task.FromResult(HealthCheckResult.Healthy("Process was successfully initialized."));
        }

        return Task.FromResult(HealthCheckResult.Unhealthy("Process is still initializing."));
    }
}