namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a command to update a domain entity.
/// </summary>
public sealed class UpdateDomainEntityCommand : ICommand<DomainEntity>
{
    [JsonPropertyName("entity")]
    public DomainEntity Entity { get; init; }

    [JsonConstructor]
    public UpdateDomainEntityCommand(DomainEntity entity)
    {
        Entity = entity;
    }
}