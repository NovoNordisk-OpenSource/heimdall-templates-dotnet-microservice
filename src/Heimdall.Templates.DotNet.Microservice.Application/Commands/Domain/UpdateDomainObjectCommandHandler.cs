namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
/// Represents a command handler for updating a domain object.
/// </summary>
public sealed class UpdateDomainObjectCommandHandler(IDomainService domainService) : ICommandHandler<UpdateDomainObjectCommand, DomainObject>
{
    private readonly IDomainService _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));

    /// <summary>
    /// Handles the update domain object command.
    /// </summary>
    /// <param name="command">The update domain object command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The updated domain object.</returns>
    public async Task<DomainObject> Handle(UpdateDomainObjectCommand command, CancellationToken cancellationToken = default)
    {
        return await _domainService.AddOrUpdateDomainObjectAsync(command.EntityId, command.CapabilityIdentifier, command.Label, command.Value, cancellationToken);
    }
}