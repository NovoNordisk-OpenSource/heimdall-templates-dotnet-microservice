namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Command handler for retrieving domain entities within a specified date range.
/// </summary>
public sealed class GetDomainEntityByDateRangeCommandHandler(IDomainService domainService) : ICommandHandler<GetDomainEntityByDateRangeCommand, IEnumerable<DomainEntity>>
{
    private readonly IDomainService _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));

    /// <summary>
    ///     Handles the GetDomainEntityByDateRangeCommand by calling the domain service to retrieve domain entities within the
    ///     specified date range.
    /// </summary>
    /// <param name="command">The GetDomainEntityByDateRangeCommand containing the start and end dates.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities within the specified date range.</returns>
    public async Task<IEnumerable<DomainEntity>> Handle(GetDomainEntityByDateRangeCommand command,
        CancellationToken ct = default)
    {
        return await _domainService.GetDomainEntityByDateRangeAsync(command.StartDate, command.EndDate, ct);
    }
}