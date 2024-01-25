namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public sealed class GetDomainEntityByCapabilityIdentifierCommandHandler : ICommandHandler<GetDomainEntityByCapabilityIdentifierCommand, IEnumerable<DomainEntity>>
{
    private readonly IDomainService _domainService;

    public GetDomainEntityByCapabilityIdentifierCommandHandler(IDomainService domainService)
    {
        _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
    }

    public async Task<IEnumerable<DomainEntity>> Handle(GetDomainEntityByCapabilityIdentifierCommand command, CancellationToken ct = default)
    {
        return await _domainService.GetDomainEntityByCapabilityIdentifierAsync(command.CapabilityIdentifier, ct);
    }
}