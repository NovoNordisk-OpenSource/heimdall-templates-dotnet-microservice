using BeHeroes.CodeOps.Abstractions.Repositories;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;

namespace Heimdall.Templates.DotNet.Microservice.Domain.Repositories
{
    public interface IDomainEntityRepository : IRepository<DomainEntity>
    {
        Task<DomainEntity> GetAsync(Guid entityId, CancellationToken ct = default);
    }
}