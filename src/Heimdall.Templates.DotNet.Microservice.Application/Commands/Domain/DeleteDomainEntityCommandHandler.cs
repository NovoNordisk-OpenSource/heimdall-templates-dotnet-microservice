namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Represents a command handler for deleting a domain entity.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="DeleteDomainEntityCommandHandler" /> class.
/// </remarks>
/// <param name="domainService">The domain service.</param>
/// <exception cref="ArgumentNullException">Thrown when the domainService is null.</exception>
public sealed class DeleteDomainEntityCommandHandler(IDomainService domainService) : ICommandHandler<DeleteDomainEntityCommand, bool>
{
    private readonly IDomainService _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));

    /// <summary>
    ///     Handles the delete domain entity command.
    /// </summary>
    /// <param name="command">The delete domain entity command.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>
    ///     A task representing the asynchronous operation. The task result contains a boolean indicating whether the
    ///     entity was deleted successfully.
    /// </returns>
    public async Task<bool> Handle(DeleteDomainEntityCommand command, CancellationToken ct = default)
    {
        return await _domainService.DeleteDomainEntityAsync(command.EntityId, ct);
    }
}