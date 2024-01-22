using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Repositories;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;

namespace Heimdall.Templates.DotNet.Microservice.Domain.Services
{
    public sealed class DomainService : IDomainService
    {
        private readonly IDomainEntityRepository _domainEntityRepository;

        public DomainService(IDomainEntityRepository domainEntityRepository)
        {
            _domainEntityRepository = domainEntityRepository;
        }

        public async Task<IEnumerable<DomainEntity>> GetDomainEntityByCapabilityIdentifierAsync(string capabilityIdentifier, CancellationToken ct = default)
        {
            return await _domainEntityRepository.GetAsync(r => r.Objects.Any(ci => ci.CapabilityIdentifier == capabilityIdentifier), ct);
        }

        public async Task<IEnumerable<DomainEntity>> GetDomainEntityByDateRangeAsync(DateTime startDate, DateTime? endDate, CancellationToken ct = default)
        {
            return await _domainEntityRepository.GetAsync(r => r.Created >= startDate && r.Created <= (endDate ?? DateTime.UtcNow), ct);
        }

        public async Task<DomainEntity> AddDomainEntityAsync(IEnumerable<DomainObject>? objects, CancellationToken ct = default)
        {
            var entity = new DomainEntity();

            if(objects != null)
                entity.AddDomainObject(objects);

            _domainEntityRepository.Add(entity);

            await _domainEntityRepository.UnitOfWork.SaveEntitiesAsync(ct);

            return entity;
        }

        public async Task<DomainObject> AddOrUpdateDomainObjectAsync(Guid entityId, string capabilityIdentifier, string label, string value, CancellationToken ct = default)
        {
            var @object = new DomainObject(label, value, capabilityIdentifier);
            DomainEntity entity = await _domainEntityRepository.GetAsync(entityId, ct);

            if (entity.Objects != null && !entity.Objects.Any(o => o.Equals(@object)))
            {
                entity.AddDomainObject(@object);
                await UpdateDomainEntityAsync(entity, ct);
            }

            return @object;
        }

        public async Task<bool> DeleteDomainEntityAsync(Guid entityId, CancellationToken ct = default)
        {
            var entity = await _domainEntityRepository.GetAsync(entityId);

            _domainEntityRepository.Delete(entity);

            return await _domainEntityRepository.UnitOfWork.SaveEntitiesAsync(ct);
        }

        public async Task<bool> DeleteDomainObjectAsync(Guid entityId, string label, string capabilityIdentifier, CancellationToken ct = default)
        {            
            var entity = await _domainEntityRepository.GetAsync(entityId, ct);
            var query = entity.Objects.Where(ci => ci.Label == label).AsQueryable();

            if (!string.IsNullOrEmpty(capabilityIdentifier))
                query = query.Where(o => o.CapabilityIdentifier == capabilityIdentifier);

            foreach (var o in query.AsEnumerable())
                entity.RemoveDomainObject(o);

            await UpdateDomainEntityAsync(entity, ct);

            return true;
        }

        public async Task<DomainEntity> UpdateDomainEntityAsync(DomainEntity entity, CancellationToken ct = default)
        {
            var updatedEntity = _domainEntityRepository.Update(entity);

            await _domainEntityRepository.UnitOfWork.SaveEntitiesAsync(ct);

            return updatedEntity;
        }
    }
}