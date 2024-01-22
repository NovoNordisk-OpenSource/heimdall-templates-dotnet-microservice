using BeHeroes.CodeOps.Abstractions.Events;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;

namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Domain
{
    public abstract class DomainEntityEvent : IDomainEvent
    {
        public DomainEntity? Entity { get; protected set; }
    }
}