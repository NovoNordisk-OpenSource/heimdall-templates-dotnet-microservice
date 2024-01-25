namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Represents a command handler for deleting a domain entity.
/// </summary>
public sealed class DeleteDomainEntityCommandHandler : ICommandHandler<DeleteDomainEntityCommand, bool>
{
    private readonly IDomainService _domainService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteDomainEntityCommandHandler"/> class.
    /// </summary>
    /// <param name="domainService">The domain service.</param>
    /// <exception cref="ArgumentNullException">Thrown when the domainService is null.</exception>
    public DeleteDomainEntityCommandHandler(IDomainService domainService)
    {
        _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
    }

    /// <summary>
    /// Handles the delete domain entity command.
    /// </summary>
    /// <param name="command">The delete domain entity command.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a boolean indicating whether the entity was deleted successfully.</returns>
    public async Task<bool> Handle(DeleteDomainEntityCommand command, CancellationToken ct = default)
    {
        return await _domainService.DeleteDomainEntityAsync(command.EntityId, ct);
    }
}