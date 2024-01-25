namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.Events.Domain;

/// <summary>
///     Handles the integration event when a domain entity is created.
/// </summary>
public class DomainEntityCreatedIntegrationEventHandler : IEventHandler<DomainEntityCreatedIntegrationEvent>
{
    private readonly Counter<int> _eventCounter = Metrics.EventMeter.CreateCounter<int>("event.counter",
        description: "Counts the number of events processed by the handler");

    private readonly IProducer<Ignore, IIntegrationEvent> _producer;

    public DomainEntityCreatedIntegrationEventHandler(IProducer<Ignore, IIntegrationEvent> producer)
    {
        _producer = producer;
    }

    /// <summary>
    ///     Handles the domain entity created integration event.
    /// </summary>
    /// <param name="notification">The integration event notification.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(DomainEntityCreatedIntegrationEvent notification, CancellationToken ct = default)
    {
        using var activity = Activities.ApplicationActivitySource.StartActivity(string.Format("{0}.{1}",
            MethodBase.GetCurrentMethod()!.DeclaringType!.FullName, MethodBase.GetCurrentMethod()!.Name));

        // Increment custom metric
        _eventCounter.Add(1);

        //TODO: Fetch topic from injected options
        await _producer.ProduceAsync("topic", new Message<Ignore, IIntegrationEvent> { Value = notification }, ct);
    }
}