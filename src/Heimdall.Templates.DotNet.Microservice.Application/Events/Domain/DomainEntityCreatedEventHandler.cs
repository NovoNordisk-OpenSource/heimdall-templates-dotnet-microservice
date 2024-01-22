using AutoMapper;
using BeHeroes.CodeOps.Abstractions.Events;
using Heimdall.Templates.DotNet.Microservice.Domain.Events.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Heimdall.Templates.DotNet.Microservice.Application.Events.Domain
{
    public sealed class DomainEntityCreatedEventHandler : IEventHandler<DomainEntityCreatedEvent>
    {
        private readonly IMapper _mapper;

        private readonly IMediator _mediator;

        public DomainEntityCreatedEventHandler(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Handle(DomainEntityCreatedEvent @event, CancellationToken ct = default)
        {
            await _mediator.Publish(_mapper.Map<DomainEntityCreatedIntegrationEvent>(@event), ct);
        }
    }
}