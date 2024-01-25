namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class DeleteDomainEntityCommandHandler : ICommandHandler<DeleteDomainEntityCommand, bool>
{
    private readonly IDomainService _domainService;

    public DeleteDomainEntityCommandHandler(IDomainService domainService)
    {
        _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
    }

    public async Task<bool> Handle(DeleteDomainEntityCommand command, CancellationToken ct = default)
    {
        return await _domainService.DeleteDomainEntityAsync(command.EntityId, ct);
    }
}