namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public sealed class GetDomainEntitiesCommandHandler : ICommandHandler<GetDomainEntitiesCommand, IEnumerable<DomainEntity>>
{
    private readonly IDomainService _domainService;

    public GetDomainEntitiesCommandHandler(IDomainService domainService)
    {
        _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
    }

    public async Task<IEnumerable<DomainEntity>> Handle(GetDomainEntitiesCommand command, CancellationToken ct = default)
    {
        return await _domainService.GetDomainEntitiesAsync(ct);
    }
}