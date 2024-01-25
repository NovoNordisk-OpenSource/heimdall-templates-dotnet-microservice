namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Represents a command to retrieve a collection of domain entities.
/// </summary>
public sealed class GetDomainEntitiesCommand : ICommand<IEnumerable<DomainEntity>>
{
    [JsonConstructor]
    public GetDomainEntitiesCommand()
    {
    }
}