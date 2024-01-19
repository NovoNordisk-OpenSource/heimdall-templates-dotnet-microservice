using BeHeroes.CodeOps.Abstractions.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects
{
    public sealed class SampleItem : ValueObject
    {
        [Required]
        [JsonPropertyName("label")]
        public string Label { get; init; }

        [Required]
        [JsonPropertyName("value")]
        public string Value { get; init; }

        [Required]
        [JsonPropertyName("capabilityIdentifier")]
        public string CapabilityIdentifier { get; init; }

        [JsonConstructor]
        public SampleItem(string label, string value, string capabilityIdentifier)
        {
            Label = label;
            Value = value;
            CapabilityIdentifier = capabilityIdentifier;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Label;
            yield return Value;
            yield return CapabilityIdentifier;
        }
    }
}