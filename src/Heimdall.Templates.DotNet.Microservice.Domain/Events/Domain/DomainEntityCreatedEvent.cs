namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Domain;

using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;

public sealed class DomainEntityCreatedEvent : DomainEntityEvent
{
    public DomainEntityCreatedEvent(DomainEntity entity)
    {
        Entity = entity;
    }
}