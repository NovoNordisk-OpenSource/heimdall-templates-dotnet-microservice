namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

/// <summary>
///     Represents a command handler for creating a domain entity.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="CreateDomainEntityCommandHandler" /> class.
/// </remarks>
/// <param name="domainService">The domain service.</param>
/// <exception cref="ArgumentNullException">Thrown when the domainService is null.</exception>
public sealed class CreateDomainEntityCommandHandler(IDomainService domainService) : ICommandHandler<CreateDomainEntityCommand, DomainEntity>, ICommandHandler<CreateDomainEntityCommand, IAggregateRoot>
{
    private readonly IDomainService _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));

    /// <summary>
    ///     Handles the create domain entity command.
    /// </summary>
    /// <param name="command">The create domain entity command.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The created domain entity.</returns>
    public async Task<DomainEntity> Handle(CreateDomainEntityCommand command, CancellationToken ct = default)
    {
        return await _domainService.AddDomainEntityAsync(command.Objects, ct);
    }

    async Task<IAggregateRoot> IRequestHandler<CreateDomainEntityCommand, IAggregateRoot>.Handle(
        CreateDomainEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }

    async Task<IAggregateRoot> ICommandHandler<CreateDomainEntityCommand, IAggregateRoot>.Handle(
        CreateDomainEntityCommand request, CancellationToken ct)
    {
        return await Handle(request, ct);
    }
}