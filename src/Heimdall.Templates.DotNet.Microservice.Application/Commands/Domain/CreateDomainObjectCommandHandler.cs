namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
/// Represents a command handler for creating a domain object.
/// </summary>
public sealed class CreateDomainObjectCommandHandler(IDomainService domainService) : ICommandHandler<CreateDomainObjectCommand, DomainObject>
{
    private readonly IDomainService _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));

    /// <summary>
    /// Handles the create domain object command.
    /// </summary>
    /// <param name="command">The create domain object command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The created domain object.</returns>
    public async Task<DomainObject> Handle(CreateDomainObjectCommand command, CancellationToken cancellationToken = default)
    {
        return await _domainService.AddOrUpdateDomainObjectAsync(command.EntityId, command.CapabilityIdentifier, command.Label, command.Value, cancellationToken);
    }
}