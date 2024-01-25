namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Domain;

/// <summary>
///     Represents an event that is raised when a domain object is added.
/// </summary>
public sealed class DomainObjectAddedEvent : DomainEntityEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="DomainObjectAddedEvent" /> class.
    /// </summary>
    /// <param name="entity">The domain entity to which the object was added.</param>
    /// <param name="object">The domain object that was added.</param>
    public DomainObjectAddedEvent(DomainEntity entity, DomainObject @object)
    {
        Entity = entity;
        Object = @object;
    }

    /// <summary>
    ///     Gets the domain object that was added.
    /// </summary>
    public DomainObject Object { get; private set; }
}