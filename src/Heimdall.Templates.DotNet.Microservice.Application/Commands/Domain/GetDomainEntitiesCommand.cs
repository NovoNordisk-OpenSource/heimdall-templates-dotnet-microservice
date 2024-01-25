namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a command to retrieve a collection of domain entities.
/// </summary>
public sealed class GetDomainEntitiesCommand : ICommand<IEnumerable<DomainEntity>>
{
    [JsonConstructor]
    public GetDomainEntitiesCommand()
    {
    }
}