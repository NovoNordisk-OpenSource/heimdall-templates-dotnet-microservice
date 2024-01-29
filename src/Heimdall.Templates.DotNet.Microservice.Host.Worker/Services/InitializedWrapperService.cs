namespace Heimdall.Templates.DotNet.Microservice.Host.Worker;

public class InitializedWrapperService<T>(T innerService, InitializedHealthCheck? initializedHealthCheck = default) : BackgroundService where T : BackgroundService
{
    private readonly T _innerService = innerService;
    private readonly InitializedHealthCheck? _initializedHealthCheck = initializedHealthCheck;

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        await _innerService.StartAsync(cancellationToken);

        await base.StartAsync(cancellationToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await _innerService.StopAsync(cancellationToken);

        await base.StopAsync(cancellationToken);
    }

    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        if(_initializedHealthCheck != null)
            _initializedHealthCheck.Initialized = true;

        return Task.CompletedTask;
    }
}