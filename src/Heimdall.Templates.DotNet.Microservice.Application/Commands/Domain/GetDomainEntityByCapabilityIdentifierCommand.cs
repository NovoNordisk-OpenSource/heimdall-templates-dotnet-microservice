namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public sealed class GetDomainEntityByCapabilityIdentifierCommand : ICommand<IEnumerable<DomainEntity>>
{
    [JsonPropertyName("capabilityIdentifier")]
    public string CapabilityIdentifier { get; init; }

    [JsonConstructor]
    public GetDomainEntityByCapabilityIdentifierCommand(string capabilityIdentifier)
    {
        CapabilityIdentifier = capabilityIdentifier;
    }
}