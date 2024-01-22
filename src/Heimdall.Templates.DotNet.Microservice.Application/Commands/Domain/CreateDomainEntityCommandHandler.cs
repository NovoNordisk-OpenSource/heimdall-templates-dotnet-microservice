using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain
{
    public sealed class CreateDomainEntityCommandHandler : ICommandHandler<CreateDomainEntityCommand, DomainEntity>, ICommandHandler<CreateDomainEntityCommand, IAggregateRoot>
    {
        private readonly IDomainService _domainService;

        public CreateDomainEntityCommandHandler(IDomainService domainService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
        }

        public async Task<DomainEntity> Handle(CreateDomainEntityCommand command, CancellationToken ct = default)
        {
            return await _domainService.AddDomainEntityAsync(command.Objects, ct);
        }

        async Task<IAggregateRoot> IRequestHandler<CreateDomainEntityCommand, IAggregateRoot>.Handle(CreateDomainEntityCommand request, CancellationToken ct)
        {
            return await Handle(request, ct);
        }

        async Task<IAggregateRoot> ICommandHandler<CreateDomainEntityCommand, IAggregateRoot>.Handle(CreateDomainEntityCommand request, CancellationToken ct)
        {
            return await Handle(request, ct);
        }
    }
}