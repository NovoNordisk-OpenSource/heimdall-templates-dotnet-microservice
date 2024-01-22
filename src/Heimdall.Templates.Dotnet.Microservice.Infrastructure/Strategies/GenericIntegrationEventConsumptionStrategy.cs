using AutoMapper;
using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Abstractions.Commands;
using BeHeroes.CodeOps.Abstractions.Events;
using BeHeroes.CodeOps.Abstractions.Strategies;
using BeHeroes.CodeOps.Infrastructure.Kafka.Strategies;
using Heimdall.Templates.DotNet.Microservice.Application;
using Confluent.Kafka;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.Strategies
{
    public sealed class GenericIntegrationEventConsumptionStrategy : ConsumptionStrategy
    {
        public GenericIntegrationEventConsumptionStrategy(IMapper mapper, IApplicationFacade applicationFacade) : base(mapper, applicationFacade)
        {
        }

        public override async Task Apply(ConsumeResult<string, string> target, CancellationToken ct = default)
        {
            var payload = target.Message.Value;

            if (!string.IsNullOrEmpty(payload))
            {
                var @event = JsonSerializer.Deserialize<IntegrationEvent>(payload);
                var aggregateRoot = _mapper.Map<IAggregateRoot>(@event);
                var command = _mapper.Map<IAggregateRoot, ICommand<IAggregateRoot>>(aggregateRoot);

                if (command != null)
                {
                    await _applicationFacade.Execute(command, ct);
                }
            }

            return;
        }
    }
}
