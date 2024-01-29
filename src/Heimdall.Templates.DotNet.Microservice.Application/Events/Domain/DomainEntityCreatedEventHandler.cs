namespace Heimdall.Templates.DotNet.Microservice.Application.Events.Domain;

/// <summary>
///     Represents an event handler for the <see cref="DomainEntityCreatedEvent" /> event.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="DomainEntityCreatedEventHandler" /> class.
/// </remarks>
/// <param name="mapper">The AutoMapper instance.</param>
/// <param name="mediator">The MediatR instance.</param>
public sealed class DomainEntityCreatedEventHandler(IMapper mapper, IMediator mediator) : IEventHandler<DomainEntityCreatedEvent>
{
    private readonly IMapper _mapper = mapper;

    private readonly IMediator _mediator = mediator;

    /// <summary>
    ///     Handles the <see cref="DomainEntityCreatedEvent" /> event.
    /// </summary>
    /// <param name="event">The event to handle.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(DomainEntityCreatedEvent @event, CancellationToken ct = default)
    {
        await _mediator.Publish(_mapper.Map<DomainEntityCreatedIntegrationEvent>(@event), ct);
    }
}