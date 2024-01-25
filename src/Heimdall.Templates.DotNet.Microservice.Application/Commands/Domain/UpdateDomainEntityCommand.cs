namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Represents a command to update a domain entity.
/// </summary>
public sealed class UpdateDomainEntityCommand : ICommand<DomainEntity>
{
    [JsonConstructor]
    public UpdateDomainEntityCommand(DomainEntity entity)
    {
        Entity = entity;
    }

    [JsonPropertyName("entity")] public DomainEntity Entity { get; init; }
}