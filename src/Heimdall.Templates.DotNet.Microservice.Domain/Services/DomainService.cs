using Heimdall.Templates.DotNet.Microservice.Domain.Repositories;

namespace Heimdall.Templates.DotNet.Microservice.Domain.Services;

/// <summary>
///     Represents a domain service that provides operations related to domain entities.
/// </summary>
public sealed class DomainService(IDomainEntityRepository domainEntityRepository) : IDomainService
{
    private readonly IDomainEntityRepository _domainEntityRepository = domainEntityRepository;
    
    /// <summary>
    ///     Retrieves all domain entities asynchronously.
    /// </summary>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities.</returns>
    public async Task<IEnumerable<DomainEntity>> GetDomainEntitiesAsync(CancellationToken ct = default)
    {
        return await _domainEntityRepository.GetAsync(o => true, ct);
    }

    /// <summary>
    ///     Retrieves a domain entity by its identifier asynchronously.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The domain entity with the specified identifier, or null if not found.</returns>
    public async Task<DomainEntity?> GetDomainEntityByIdAsync(Guid entityId, CancellationToken ct = default)
    {
        return await _domainEntityRepository.GetAsync(entityId, ct);
    }

    /// <summary>
    ///     Retrieves domain entities by capability identifier asynchronously.
    /// </summary>
    /// <param name="capabilityIdentifier">The capability identifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities.</returns>
    public async Task<IEnumerable<DomainEntity>> GetDomainEntityByCapabilityIdentifierAsync(string capabilityIdentifier, CancellationToken ct = default)
    {
        return await _domainEntityRepository.GetAsync(r => r.Objects.Any(ci => ci.CapabilityIdentifier == capabilityIdentifier), ct);
    }

    /// <summary>
    ///     Retrieves domain entities by date range asynchronously.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date (optional).</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities.</returns>
    public async Task<IEnumerable<DomainEntity>> GetDomainEntityByDateRangeAsync(DateTime startDate, DateTime? endDate, CancellationToken ct = default)
    {
        return await _domainEntityRepository.GetAsync(r => r.Created >= startDate && r.Created <= (endDate ?? DateTime.UtcNow), ct);
    }

    /// <summary>
    ///     Adds a new domain entity asynchronously.
    /// </summary>
    /// <param name="objects">The collection of domain objects (optional).</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The added domain entity.</returns>
    public async Task<DomainEntity> AddDomainEntityAsync(IEnumerable<DomainObject>? objects, CancellationToken ct = default)
    {
        var entity = new DomainEntity();

        if (objects != null)
            entity.AddDomainObject(objects);

        _domainEntityRepository.Add(entity);

        await _domainEntityRepository.UnitOfWork.SaveEntitiesAsync(ct);

        return entity;
    }

    /// <summary>
    ///     Adds or updates a domain object asynchronously.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <param name="capabilityIdentifier">The capability identifier.</param>
    /// <param name="label">The label.</param>
    /// <param name="value">The value.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The added or updated domain object.</returns>
    public async Task<DomainObject> AddOrUpdateDomainObjectAsync(Guid entityId, string capabilityIdentifier, string label, string value, CancellationToken ct = default)
    {
        var @object = new DomainObject(label, value, capabilityIdentifier);
        var entity = await _domainEntityRepository.GetAsync(entityId, ct);

        if (entity is not null && entity.Objects != null && !entity.Objects.Any(o => o.Equals(@object)))
        {
            entity.AddDomainObject(@object);
            await UpdateDomainEntityAsync(entity, ct);
        }

        return @object;
    }

    /// <summary>
    ///     Deletes a domain entity asynchronously.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>True if the domain entity is deleted, otherwise false.</returns>
    public async Task<bool> DeleteDomainEntityAsync(Guid entityId, CancellationToken ct = default)
    {
        var entity = await _domainEntityRepository.GetAsync(entityId);

        if (entity is not null) _domainEntityRepository.Delete(entity);

        return await _domainEntityRepository.UnitOfWork.SaveEntitiesAsync(ct);
    }

    /// <summary>
    ///     Deletes a domain object asynchronously.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <param name="label">The label.</param>
    /// <param name="capabilityIdentifier">The capability identifier (optional).</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>True if the domain object is deleted, otherwise false.</returns>
    public async Task<bool> DeleteDomainObjectAsync(Guid entityId, string label, string? capabilityIdentifier, CancellationToken ct = default)
    {
        var entity = await _domainEntityRepository.GetAsync(entityId, ct);

        if (entity is not null)
        {
            var query = entity.Objects.Where(ci => ci.Label == label).AsQueryable();

            if (!string.IsNullOrEmpty(capabilityIdentifier))
                query = query.Where(o => o.CapabilityIdentifier == capabilityIdentifier);

            foreach (var o in query.AsEnumerable())
                entity.RemoveDomainObject(o);

            await UpdateDomainEntityAsync(entity, ct);

            return true;
        }

        return false;
    }

    /// <summary>
    ///     Updates a domain entity asynchronously.
    /// </summary>
    /// <param name="entity">The domain entity.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The updated domain entity.</returns>
    public async Task<DomainEntity> UpdateDomainEntityAsync(DomainEntity entity, CancellationToken ct = default)
    {
        var updatedEntity = _domainEntityRepository.Update(entity);

        await _domainEntityRepository.UnitOfWork.SaveEntitiesAsync(ct);

        return updatedEntity;
    }
}