namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Command handler for retrieving domain entities within a specified date range.
/// </summary>
public sealed class GetDomainEntityByDateRangeCommandHandler : ICommandHandler<GetDomainEntityByDateRangeCommand, IEnumerable<DomainEntity>>
{
    private readonly IDomainService _domainService;

    public GetDomainEntityByDateRangeCommandHandler(IDomainService domainService)
    {
        _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
    }

    /// <summary>
    /// Handles the GetDomainEntityByDateRangeCommand by calling the domain service to retrieve domain entities within the specified date range.
    /// </summary>
    /// <param name="command">The GetDomainEntityByDateRangeCommand containing the start and end dates.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities within the specified date range.</returns>
    public async Task<IEnumerable<DomainEntity>> Handle(GetDomainEntityByDateRangeCommand command, CancellationToken ct = default)
    {
        return await _domainService.GetDomainEntityByDateRangeAsync(command.StartDate, command.EndDate, ct);
    }
}