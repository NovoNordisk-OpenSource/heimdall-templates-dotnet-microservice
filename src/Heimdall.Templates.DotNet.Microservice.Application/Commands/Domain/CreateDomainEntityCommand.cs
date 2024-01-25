namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Represents a command to create a domain entity.
/// </summary>
public sealed class CreateDomainEntityCommand : ICommand<DomainEntity>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CreateDomainEntityCommand" /> class.
    /// </summary>
    /// <param name="objects">The collection of domain objects associated with the entity.</param>
    [JsonConstructor]
    public CreateDomainEntityCommand(IEnumerable<DomainObject> objects)
    {
        Objects = objects;
    }

    /// <summary>
    ///     Gets or sets the collection of domain objects associated with the entity.
    /// </summary>
    [JsonPropertyName("objects")]
    public IEnumerable<DomainObject> Objects { get; init; }
}