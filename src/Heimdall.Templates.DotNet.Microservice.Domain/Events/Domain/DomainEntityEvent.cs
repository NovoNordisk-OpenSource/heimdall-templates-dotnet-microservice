namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Domain;

/// <summary>
///     Represents a domain entity event.
/// </summary>
public abstract class DomainEntityEvent : IDomainEvent
{
    /// <summary>
    ///     Gets or sets the domain entity associated with the event.
    /// </summary>
    public DomainEntity? Entity { get; protected set; }
}