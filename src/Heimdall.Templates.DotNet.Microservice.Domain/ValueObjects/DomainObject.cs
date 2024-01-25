namespace Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;

using BeHeroes.CodeOps.Abstractions.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

[method: JsonConstructor]
public sealed class DomainObject(string label, string value, string capabilityIdentifier) : ValueObject
{
    [Required]
    [JsonPropertyName("label")]
    public string Label { get; init; } = label;

    [Required]
    [JsonPropertyName("value")]
    public string Value { get; init; } = value;

    [Required]
    [JsonPropertyName("capabilityIdentifier")]
    public string CapabilityIdentifier { get; init; } = capabilityIdentifier;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Label;
        yield return Value;
        yield return CapabilityIdentifier;
    }
}