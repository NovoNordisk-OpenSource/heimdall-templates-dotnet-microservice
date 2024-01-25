namespace Heimdall.Templates.DotNet.Microservice.Domain.Services;

using BeHeroes.CodeOps.Abstractions.Services;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;

public interface IDomainService : IService
{
    Task<IEnumerable<DomainEntity>> GetDomainEntitiesAsync(CancellationToken ct = default);

    Task<IEnumerable<DomainEntity>> GetDomainEntityByCapabilityIdentifierAsync(string capabilityIdentifier, CancellationToken ct = default);

    Task<IEnumerable<DomainEntity>> GetDomainEntityByDateRangeAsync(DateTime startDate, DateTime? endDate, CancellationToken ct = default);

    Task<DomainEntity> AddDomainEntityAsync(IEnumerable<DomainObject>? objects, CancellationToken ct = default);

    Task<DomainEntity> UpdateDomainEntityAsync(DomainEntity entity, CancellationToken ct = default);

    Task<bool> DeleteDomainEntityAsync(Guid entityId, CancellationToken ct = default);

    Task<DomainObject> AddOrUpdateDomainObjectAsync(Guid entityId, string capabilityIdentifier, string label, string value, CancellationToken ct = default);

    Task<bool> DeleteDomainObjectAsync(Guid entityId, string label, string capabilityIdentifier, CancellationToken ct = default);
}