namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
/// Initializes a new instance of the <see cref="CreateDomainObjectCommand"/> class.
/// </summary>
/// <param name="entityId">The entity identifier.</param>
/// <param name="label">The label.</param>
/// <param name="capabilityIdentifier">The capability identifier.</param>
[method: JsonConstructor]
public sealed class DeleteDomainObjectCommand(Guid entityId, string label, string? capabilityIdentifier = default) : ICommand<bool>
{
    /// <summary>
    /// Gets or sets the capability identifier associated with the domain object.
    /// </summary>
    [JsonPropertyName("capabilityIdentifier")]
    public string? CapabilityIdentifier { get; init; } = capabilityIdentifier;

    /// <summary>
    /// Gets or sets the label of the domain object.
    /// </summary>
    [JsonPropertyName("label")]
    public string Label { get; init; } = label;

    /// <summary>
    /// Gets or sets the ID of the domain object.
    /// </summary>
    [JsonPropertyName("entityId")]
    public Guid EntityId { get; init; } = entityId;
}