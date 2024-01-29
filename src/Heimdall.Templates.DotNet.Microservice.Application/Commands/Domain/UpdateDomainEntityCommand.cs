namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Represents a command to update a domain entity.
/// </summary>
[method: JsonConstructor]
/// <summary>
///     Represents a command to update a domain entity.
/// </summary>
public sealed class UpdateDomainEntityCommand(DomainEntity entity) : ICommand<DomainEntity>
{
    [JsonPropertyName("entity")] public DomainEntity Entity { get; init; } = entity;
}