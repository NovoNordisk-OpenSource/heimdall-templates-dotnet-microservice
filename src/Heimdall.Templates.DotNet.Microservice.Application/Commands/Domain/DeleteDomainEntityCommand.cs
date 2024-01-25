namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using System;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a command to delete a domain entity.
/// </summary>
public sealed class DeleteDomainEntityCommand : ICommand<bool>
{
    /// <summary>
    /// Gets or sets the ID of the entity to be deleted.
    /// </summary>
    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteDomainEntityCommand"/> class.
    /// </summary>
    /// <param name="entityId">The ID of the entity to be deleted.</param>
    [JsonConstructor]
    public DeleteDomainEntityCommand(Guid entityId)
    {
        EntityId = entityId;
    }
}