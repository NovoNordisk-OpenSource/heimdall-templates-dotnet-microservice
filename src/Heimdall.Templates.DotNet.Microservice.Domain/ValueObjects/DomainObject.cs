namespace Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;

/// <summary>
///     Represents a domain object with a label, value, and capability identifier.
/// </summary>
/// <remarks>
///     Value objects are a concept in software development that represent a descriptive aspect of the domain with no
///     conceptual identity. In simpler terms, value objects are objects whose equality is determined by the value of their
///     attributes rather than by their identity.
///     They are used to model attributes or characteristics of entities (aggregates) in a domain.
/// </remarks>
[method: JsonConstructor]
public sealed class DomainObject(string label, string value, string capabilityIdentifier) : ValueObject
{
    /// <summary>
    ///     Gets or sets the label of the domain object.
    /// </summary>
    [Required]
    [JsonPropertyName("label")]
    public string Label { get; init; } = label;

    /// <summary>
    ///     Gets or sets the value of the domain object.
    /// </summary>
    [Required]
    [JsonPropertyName("value")]
    public string Value { get; init; } = value;

    /// <summary>
    ///     Gets or sets the capability identifier of the domain object.
    /// </summary>
    [Required]
    [JsonPropertyName("capabilityIdentifier")]
    public string CapabilityIdentifier { get; init; } = capabilityIdentifier;

    /// <summary>
    ///     Returns the atomic values of the domain object.
    /// </summary>
    /// <returns>An enumerable of the atomic values.</returns>
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Label;
        yield return Value;
        yield return CapabilityIdentifier;
    }
}