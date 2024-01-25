namespace Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;

using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Abstractions.Entities;
using Heimdall.Templates.DotNet.Microservice.Domain.Events.Domain;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

public sealed class DomainEntity : Entity<Guid>, IAggregateRoot
{
    private readonly List<DomainObject> _objects;

    private readonly DateTime _created = DateTime.UtcNow;

    public IEnumerable<DomainObject> Objects => _objects.AsReadOnly();

    public DateTime Created => _created;

    public DomainEntity()
    {
        _objects = [];

        var evt = new DomainEntityCreatedEvent(this);

        AddDomainEvent(evt);
    }

    public DomainEntity(DateTime created) : this()
    {
        _created = created;
    }

    public void AddDomainObject(DomainObject @object)
    {
        _objects.Add(@object);

        var evt = new DomainObjectAddedEvent(this, @object);

        AddDomainEvent(evt);
    }

    public void AddDomainObject(IEnumerable<DomainObject> @object)
    {
        foreach(var obj in @object) 
            AddDomainObject(obj);
    }

    public void RemoveDomainObject(DomainObject @object)
    {
        _objects.Remove(@object);

        var evt = new DomainObjectAddedEvent(this, @object);

        AddDomainEvent(evt);
    }

    public void RemoveDomainObject(IEnumerable<DomainObject> @object)
    {
        foreach (var obj in @object)
            RemoveDomainObject(obj);
    }

    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return [];
    }
}