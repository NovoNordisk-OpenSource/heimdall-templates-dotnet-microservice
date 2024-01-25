namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.Events.Domain;

using AutoMapper;
using BeHeroes.CodeOps.Abstractions.Events;
using Confluent.Kafka;
using System.Threading;
using System.Threading.Tasks;
using Heimdall.Templates.DotNet.Microservice.Application.Events.Domain;
using Heimdall.Templates.DotNet.Microservice.Application.Telemetry;

public class DomainEntityCreatedIntegrationEventHandler : IEventHandler<DomainEntityCreatedIntegrationEvent>
{
    private readonly IProducer<Ignore, IIntegrationEvent> _producer;

    private readonly System.Diagnostics.Metrics.Counter<int> _eventCounter = Metrics.EventMeter.CreateCounter<int>("event.count", description: "Counts the number of events processed by the handler");

    public DomainEntityCreatedIntegrationEventHandler(IProducer<Ignore, IIntegrationEvent> producer)
    {
        _producer = producer;
    }

    public async Task Handle(DomainEntityCreatedIntegrationEvent notification, CancellationToken ct = default)
    {
        using var activity = Activities.ApplicationActivitySource.StartActivity(typeof(DomainEntityCreatedIntegrationEventHandler).ToString());
        
        // Increment custom metric
        _eventCounter.Add(1);

        //TODO: Fetch topic from injected options
        await _producer.ProduceAsync("topic", new Message<Ignore, IIntegrationEvent> { Value=notification }, ct);
    }
}