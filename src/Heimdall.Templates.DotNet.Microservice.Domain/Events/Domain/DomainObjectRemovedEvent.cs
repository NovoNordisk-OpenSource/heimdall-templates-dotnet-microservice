namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Domain;

using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;

public sealed class DomainObjectRemovedEvent : DomainEntityEvent
{
    public DomainObject Object { get; private set; }

    public DomainObjectRemovedEvent(DomainEntity entity, DomainObject @object)
    {
        Entity = entity;
        Object = @object;
    }
}