namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Domain;

using BeHeroes.CodeOps.Abstractions.Events;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;

/// <summary>
/// Represents a domain entity event.
/// </summary>
public abstract class DomainEntityEvent : IDomainEvent
{
    /// <summary>
    /// Gets or sets the domain entity associated with the event.
    /// </summary>
    public DomainEntity? Entity { get; protected set; }
}