using BeHeroes.CodeOps.Abstractions.Events;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;

namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Report
{
    public abstract class SampleEvent : IDomainEvent
    {
        public SampleRoot? SampleRoot { get; protected set; }
    }
}