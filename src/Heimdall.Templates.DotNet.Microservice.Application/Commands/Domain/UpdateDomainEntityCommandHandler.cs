namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class UpdateDomainEntityCommandHandler : ICommandHandler<UpdateDomainEntityCommand, DomainEntity>, ICommandHandler<UpdateDomainEntityCommand, IAggregateRoot>
{
    private readonly IDomainService _domainService;

    public UpdateDomainEntityCommandHandler(IDomainService domainService)
    {
        _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
    }

    public async Task<DomainEntity> Handle(UpdateDomainEntityCommand command, CancellationToken ct = default)
    {
        return await _domainService.UpdateDomainEntityAsync(command.Entity, ct);
    }

    async Task<IAggregateRoot> IRequestHandler<UpdateDomainEntityCommand, IAggregateRoot>.Handle(UpdateDomainEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }

    async Task<IAggregateRoot> ICommandHandler<UpdateDomainEntityCommand, IAggregateRoot>.Handle(UpdateDomainEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }
}