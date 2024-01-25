namespace Heimdall.Templates.DotNet.Microservice.Application.Events.Domain;

/// <summary>
///     Represents an event handler for the <see cref="DomainEntityCreatedEvent" /> event.
/// </summary>
public sealed class DomainEntityCreatedEventHandler : IEventHandler<DomainEntityCreatedEvent>
{
    private readonly IMapper _mapper;

    private readonly IMediator _mediator;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DomainEntityCreatedEventHandler" /> class.
    /// </summary>
    /// <param name="mapper">The AutoMapper instance.</param>
    /// <param name="mediator">The MediatR instance.</param>
    public DomainEntityCreatedEventHandler(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

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