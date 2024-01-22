using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain
{
    public sealed class GetDomainEntityByDateRangeCommandHandler : ICommandHandler<GetDomainEntityByDateRangeCommand, IEnumerable<DomainEntity>>
    {
        private readonly IDomainService _domainService;

        public GetDomainEntityByDateRangeCommandHandler(IDomainService domainService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
        }

        public async Task<IEnumerable<DomainEntity>> Handle(GetDomainEntityByDateRangeCommand command, CancellationToken ct = default)
        {
            return await _domainService.GetDomainEntityByDateRangeAsync(command.StartDate, command.EndDate, ct);
        }
    }
}