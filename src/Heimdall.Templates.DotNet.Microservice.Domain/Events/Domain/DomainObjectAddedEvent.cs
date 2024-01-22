using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;

namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Domain
{
    public sealed class DomainObjectAddedEvent : DomainEntityEvent
    {
        public DomainObject Object { get; private set; }

        public DomainObjectAddedEvent(DomainEntity entity, DomainObject @object)
        {
            Entity = entity;
            Object = @object;
        }
    }
}