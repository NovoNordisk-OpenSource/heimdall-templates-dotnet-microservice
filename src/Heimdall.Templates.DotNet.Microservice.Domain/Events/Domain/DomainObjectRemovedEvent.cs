namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Domain;

/// <summary>
///     Represents an event that is raised when a domain object is removed.
/// </summary>
public sealed class DomainObjectRemovedEvent : DomainEntityEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="DomainObjectRemovedEvent" /> class.
    /// </summary>
    /// <param name="entity">The domain entity from which the object was removed.</param>
    /// <param name="object">The domain object that was removed.</param>
    public DomainObjectRemovedEvent(DomainEntity entity, DomainObject @object)
    {
        Entity = entity;
        Object = @object;
    }

    /// <summary>
    ///     Gets the domain object that was removed.
    /// </summary>
    public DomainObject Object { get; private set; }
}