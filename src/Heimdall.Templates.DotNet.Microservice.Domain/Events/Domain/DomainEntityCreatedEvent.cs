using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;

namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Domain
{
    public sealed class DomainEntityCreatedEvent : DomainEntityEvent
    {
        public DomainEntityCreatedEvent(DomainEntity entity)
        {
            Entity = entity;
        }
    }
}