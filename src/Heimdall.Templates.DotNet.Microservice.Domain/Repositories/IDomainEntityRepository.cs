namespace Heimdall.Templates.DotNet.Microservice.Domain.Repositories;

using BeHeroes.CodeOps.Abstractions.Repositories;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;

public interface IDomainEntityRepository : IRepository<DomainEntity>
{
    Task<DomainEntity> GetAsync(Guid entityId, CancellationToken ct = default);
}