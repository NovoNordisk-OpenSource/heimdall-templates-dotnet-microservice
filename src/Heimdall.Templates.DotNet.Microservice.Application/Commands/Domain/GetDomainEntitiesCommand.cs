using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain
{
    public sealed class GetDomainEntitiesCommand : ICommand<IEnumerable<DomainEntity>>
    {
        [JsonConstructor]
        public GetDomainEntitiesCommand()
        {
        }
    }
}