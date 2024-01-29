namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Represents a command to create a domain entity.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="CreateDomainEntityCommand" /> class.
/// </remarks>
/// <param name="objects">The collection of domain objects associated with the entity.</param>
[method: JsonConstructor]
public sealed class CreateDomainEntityCommand(IEnumerable<DomainObject> objects) : ICommand<DomainEntity>
{
    /// <summary>
    ///     Gets or sets the collection of domain objects associated with the entity.
    /// </summary>
    [JsonPropertyName("objects")]
    public IEnumerable<DomainObject> Objects { get; init; } = objects;
}