namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Command handler for retrieving domain entities by capability identifier.
/// </summary>
public sealed class GetDomainEntityByCapabilityIdentifierCommandHandler : ICommandHandler<GetDomainEntityByCapabilityIdentifierCommand, IEnumerable<DomainEntity>>
{
    private readonly IDomainService _domainService;

    public GetDomainEntityByCapabilityIdentifierCommandHandler(IDomainService domainService)
    {
        _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
    }

    /// <summary>
    /// Handles the command by retrieving domain entities based on the provided capability identifier.
    /// </summary>
    /// <param name="command">The command containing the capability identifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities.</returns>
    public async Task<IEnumerable<DomainEntity>> Handle(GetDomainEntityByCapabilityIdentifierCommand command, CancellationToken ct = default)
    {
        return await _domainService.GetDomainEntityByCapabilityIdentifierAsync(command.CapabilityIdentifier, ct);
    }
}