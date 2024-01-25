namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Command handler for retrieving domain entities.
/// </summary>
public sealed class
    GetDomainEntitiesCommandHandler : ICommandHandler<GetDomainEntitiesCommand, IEnumerable<DomainEntity>>
{
    private readonly IDomainService _domainService;

    public GetDomainEntitiesCommandHandler(IDomainService domainService)
    {
        _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
    }

    /// <summary>
    ///     Handles the GetDomainEntitiesCommand by retrieving domain entities asynchronously.
    /// </summary>
    /// <param name="command">The GetDomainEntitiesCommand.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities.</returns>
    public async Task<IEnumerable<DomainEntity>> Handle(GetDomainEntitiesCommand command,
        CancellationToken ct = default)
    {
        return await _domainService.GetDomainEntitiesAsync(ct);
    }
}