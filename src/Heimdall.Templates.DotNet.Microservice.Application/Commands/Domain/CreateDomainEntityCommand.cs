namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a command to create a domain entity.
/// </summary>
public sealed class CreateDomainEntityCommand : ICommand<DomainEntity>
{
    /// <summary>
    /// Gets or sets the collection of domain objects associated with the entity.
    /// </summary>
    [JsonPropertyName("objects")]
    public IEnumerable<DomainObject> Objects { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateDomainEntityCommand"/> class.
    /// </summary>
    /// <param name="objects">The collection of domain objects associated with the entity.</param>
    [JsonConstructor]
    public CreateDomainEntityCommand(IEnumerable<DomainObject> objects)
    {
        Objects = objects;
    }
}