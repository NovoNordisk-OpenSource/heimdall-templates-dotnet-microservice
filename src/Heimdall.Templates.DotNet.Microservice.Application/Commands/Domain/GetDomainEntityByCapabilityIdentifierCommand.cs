namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a command to retrieve domain entities by capability identifier.
/// </summary>
public sealed class GetDomainEntityByCapabilityIdentifierCommand : ICommand<IEnumerable<DomainEntity>>
{
    /// <summary>
    /// Gets or sets the capability identifier.
    /// </summary>
    [JsonPropertyName("capabilityIdentifier")]
    public string CapabilityIdentifier { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetDomainEntityByCapabilityIdentifierCommand"/> class.
    /// </summary>
    /// <param name="capabilityIdentifier">The capability identifier.</param>
    [JsonConstructor]
    public GetDomainEntityByCapabilityIdentifierCommand(string capabilityIdentifier)
    {
        CapabilityIdentifier = capabilityIdentifier;
    }
}