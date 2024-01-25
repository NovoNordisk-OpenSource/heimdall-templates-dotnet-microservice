namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Domain;

/// <summary>
///     Represents an event that is raised when a domain entity is created.
/// </summary>
public sealed class DomainEntityCreatedEvent : DomainEntityEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="DomainEntityCreatedEvent" /> class.
    /// </summary>
    /// <param name="entity">The domain entity that was created.</param>
    public DomainEntityCreatedEvent(DomainEntity entity)
    {
        Entity = entity;
    }
}