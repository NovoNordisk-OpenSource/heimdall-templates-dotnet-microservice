namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Represents a command to retrieve domain entities by capability identifier.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="GetDomainEntityByCapabilityIdentifierCommand" /> class.
/// </remarks>
/// <param name="capabilityIdentifier">The capability identifier.</param>
[method: JsonConstructor]
public sealed class GetDomainEntityByCapabilityIdentifierCommand(string capabilityIdentifier) : ICommand<IEnumerable<DomainEntity>>
{
    /// <summary>
    ///     Gets or sets the capability identifier.
    /// </summary>
    [JsonPropertyName("capabilityIdentifier")]
    public string CapabilityIdentifier { get; init; } = capabilityIdentifier;
}