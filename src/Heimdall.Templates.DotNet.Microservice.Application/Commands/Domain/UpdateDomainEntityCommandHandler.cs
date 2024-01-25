namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Represents a command handler for updating a domain entity.
/// </summary>
public sealed class UpdateDomainEntityCommandHandler : ICommandHandler<UpdateDomainEntityCommand, DomainEntity>,
    ICommandHandler<UpdateDomainEntityCommand, IAggregateRoot>
{
    private readonly IDomainService _domainService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UpdateDomainEntityCommandHandler" /> class.
    /// </summary>
    /// <param name="domainService">The domain service.</param>
    /// <exception cref="ArgumentNullException">Thrown when the domainService is null.</exception>
    public UpdateDomainEntityCommandHandler(IDomainService domainService)
    {
        _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
    }

    /// <summary>
    ///     Handles the update domain entity command.
    /// </summary>
    /// <param name="command">The update domain entity command.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The updated domain entity.</returns>
    public async Task<DomainEntity> Handle(UpdateDomainEntityCommand command, CancellationToken ct = default)
    {
        return await _domainService.UpdateDomainEntityAsync(command.Entity, ct);
    }

    async Task<IAggregateRoot> IRequestHandler<UpdateDomainEntityCommand, IAggregateRoot>.Handle(
        UpdateDomainEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }

    async Task<IAggregateRoot> ICommandHandler<UpdateDomainEntityCommand, IAggregateRoot>.Handle(
        UpdateDomainEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }
}