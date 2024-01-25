namespace Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;

/// <summary>
///     Represents a domain entity.
/// </summary>
/// <remarks>
///     The Aggregate Root is a design pattern that's used in Domain-Driven Design (DDD). It's a part of the tactical
///     design patterns set which also includes Entities, Value Objects, and Domain Events.
///     An Aggregate is a cluster of domain objects that can be treated as a single unit. An example may be an Order and
///     its line-items, these will be separate objects, but it's useful to treat the Order (along with its line items) as a
///     single aggregate.
///     An Aggregate Root is the object or entity that holds the aggregate together. It's the gatekeeper to the aggregate
///     and all interactions with the aggregate should go through the Aggregate Root. In the previous example, the Order
///     would be the Aggregate Root.
///     The Aggregate Root has the following responsibilities:
///     Ensures the consistency of changes being made within the aggregate boundary: The Aggregate Root is responsible for
///     checking the validity of the operation before it changes the state of the aggregate.
///     Controls access to the aggregate: The Aggregate Root is the only point of access for other objects. This means that
///     other objects can't directly access the contained entities or value objects.
///     Maintains the lifecycle of the aggregate: The Aggregate Root is responsible for the creation and deletion of the
///     aggregate.
///     In your code, DomainEntity is an Aggregate Root as it implements the IAggregateRoot interface. This means that
///     DomainEntity is the entry point for any operations that involve the aggregate it's part of.
/// </remarks>
public sealed class DomainEntity : Entity<Guid>, IAggregateRoot
{
    private readonly List<DomainObject> _objects = [];

    /// <summary>
    ///     Initializes a new instance of the <see cref="DomainEntity" /> class.
    /// </summary>
    public DomainEntity()
    {
        var evt = new DomainEntityCreatedEvent(this);

        AddDomainEvent(evt);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="DomainEntity" /> class with the specified creation date and time.
    /// </summary>
    /// <param name="created">The creation date and time.</param>
    public DomainEntity(DateTime created) : this()
    {
        Created = created;
    }

    /// <summary>
    ///     Gets the collection of domain objects associated with this entity.
    /// </summary>
    public IEnumerable<DomainObject> Objects => _objects.AsReadOnly();

    /// <summary>
    ///     Gets the creation date and time of this entity.
    /// </summary>
    public DateTime Created { get; } = DateTime.UtcNow;

    /// <summary>
    ///     Validates the entity.
    /// </summary>
    /// <param name="validationContext">The validation context.</param>
    /// <returns>A collection of validation results.</returns>
    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return new ValidationResult[0];
    }

    /// <summary>
    ///     Adds a domain object to the collection of objects associated with this entity.
    /// </summary>
    /// <param name="object">The domain object to add.</param>
    public void AddDomainObject(DomainObject @object)
    {
        _objects.Add(@object);

        var evt = new DomainObjectAddedEvent(this, @object);

        AddDomainEvent(evt);
    }

    /// <summary>
    ///     Adds multiple domain objects to the collection of objects associated with this entity.
    /// </summary>
    /// <param name="object">The collection of domain objects to add.</param>
    public void AddDomainObject(IEnumerable<DomainObject> @object)
    {
        foreach (var obj in @object)
            AddDomainObject(obj);
    }

    /// <summary>
    ///     Removes a domain object from the collection of objects associated with this entity.
    /// </summary>
    /// <param name="object">The domain object to remove.</param>
    public void RemoveDomainObject(DomainObject @object)
    {
        _objects.Remove(@object);

        var evt = new DomainObjectAddedEvent(this, @object);

        AddDomainEvent(evt);
    }

    /// <summary>
    ///     Removes multiple domain objects from the collection of objects associated with this entity.
    /// </summary>
    /// <param name="object">The collection of domain objects to remove.</param>
    public void RemoveDomainObject(IEnumerable<DomainObject> @object)
    {
        foreach (var obj in @object)
            RemoveDomainObject(obj);
    }
}