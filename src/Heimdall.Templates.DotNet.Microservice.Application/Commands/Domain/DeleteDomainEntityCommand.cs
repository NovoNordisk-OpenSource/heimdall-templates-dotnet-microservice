namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using System;
using System.Text.Json.Serialization;

public sealed class DeleteDomainEntityCommand : ICommand<bool>
{
    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; }

    [JsonConstructor]
    public DeleteDomainEntityCommand(Guid entityId)
    {
        EntityId = entityId;
    }
}