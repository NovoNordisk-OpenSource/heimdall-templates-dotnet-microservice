namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Represents a command to retrieve domain entities by capability identifier.
/// </summary>
public sealed class GetDomainEntityByCapabilityIdentifierCommand : ICommand<IEnumerable<DomainEntity>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="GetDomainEntityByCapabilityIdentifierCommand" /> class.
    /// </summary>
    /// <param name="capabilityIdentifier">The capability identifier.</param>
    [JsonConstructor]
    public GetDomainEntityByCapabilityIdentifierCommand(string capabilityIdentifier)
    {
        CapabilityIdentifier = capabilityIdentifier;
    }

    /// <summary>
    ///     Gets or sets the capability identifier.
    /// </summary>
    [JsonPropertyName("capabilityIdentifier")]
    public string CapabilityIdentifier { get; init; }
}