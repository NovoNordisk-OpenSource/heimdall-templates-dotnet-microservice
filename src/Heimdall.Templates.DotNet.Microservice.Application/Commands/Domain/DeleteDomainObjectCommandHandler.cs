namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
/// Represents a command handler for deleting a domain object.
/// </summary>
public sealed class DeleteDomainObjectCommandHandler(IDomainService domainService) : ICommandHandler<DeleteDomainObjectCommand, bool>
{
    private readonly IDomainService _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));

    /// <summary>
    /// Handles the delete domain object command.
    /// </summary>
    /// <param name="command">The delete domain object command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task<bool> Handle(DeleteDomainObjectCommand command, CancellationToken cancellationToken = default)
    {
        return await _domainService.DeleteDomainObjectAsync(command.EntityId, command.Label, command.CapabilityIdentifier, cancellationToken);
    }
}