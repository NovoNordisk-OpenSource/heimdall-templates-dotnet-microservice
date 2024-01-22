using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using System.Text.Json.Serialization;

namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain
{
    public sealed class UpdateDomainEntityCommand : ICommand<DomainEntity>
    {
        [JsonPropertyName("entity")]
        public DomainEntity Entity { get; init; }

        [JsonConstructor]
        public UpdateDomainEntityCommand(DomainEntity entity)
        {
            Entity = entity;
        }
    }
}