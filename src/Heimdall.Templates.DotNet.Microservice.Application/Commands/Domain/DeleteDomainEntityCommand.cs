namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Represents a command to delete a domain entity.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="DeleteDomainEntityCommand" /> class.
/// </remarks>
/// <param name="entityId">The ID of the entity to be deleted.</param>
[method: JsonConstructor]
public sealed class DeleteDomainEntityCommand(Guid entityId) : ICommand<bool>
{

    /// <summary>
    ///     Gets or sets the ID of the entity to be deleted.
    /// </summary>
    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; } = entityId;
}