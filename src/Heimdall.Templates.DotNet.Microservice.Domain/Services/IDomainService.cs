namespace Heimdall.Templates.DotNet.Microservice.Domain.Services;

using BeHeroes.CodeOps.Abstractions.Services;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;

/// <summary>
/// Represents a domain service that provides operations for managing domain entities and objects.
/// </summary>
public interface IDomainService : IService
{
    /// <summary>
    /// Retrieves all domain entities.
    /// </summary>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of domain entities.</returns>
    Task<IEnumerable<DomainEntity>> GetDomainEntitiesAsync(CancellationToken ct = default);

    /// <summary>
    /// Retrieves domain entities by capability identifier.
    /// </summary>
    /// <param name="capabilityIdentifier">The capability identifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of domain entities.</returns>
    Task<IEnumerable<DomainEntity>> GetDomainEntityByCapabilityIdentifierAsync(string capabilityIdentifier, CancellationToken ct = default);

    /// <summary>
    /// Retrieves domain entities by date range.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of domain entities.</returns>
    Task<IEnumerable<DomainEntity>> GetDomainEntityByDateRangeAsync(DateTime startDate, DateTime? endDate, CancellationToken ct = default);

    /// <summary>
    /// Adds a new domain entity.
    /// </summary>
    /// <param name="objects">The collection of domain objects to be associated with the entity.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the added domain entity.</returns>
    Task<DomainEntity> AddDomainEntityAsync(IEnumerable<DomainObject>? objects, CancellationToken ct = default);

    /// <summary>
    /// Updates an existing domain entity.
    /// </summary>
    /// <param name="entity">The domain entity to be updated.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated domain entity.</returns>
    Task<DomainEntity> UpdateDomainEntityAsync(DomainEntity entity, CancellationToken ct = default);

    /// <summary>
    /// Deletes a domain entity by its identifier.
    /// </summary>
    /// <param name="entityId">The identifier of the domain entity to be deleted.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
    Task<bool> DeleteDomainEntityAsync(Guid entityId, CancellationToken ct = default);

    /// <summary>
    /// Adds or updates a domain object associated with a domain entity.
    /// </summary>
    /// <param name="entityId">The identifier of the domain entity.</param>
    /// <param name="capabilityIdentifier">The capability identifier of the domain object.</param>
    /// <param name="label">The label of the domain object.</param>
    /// <param name="value">The value of the domain object.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the added or updated domain object.</returns>
    Task<DomainObject> AddOrUpdateDomainObjectAsync(Guid entityId, string capabilityIdentifier, string label, string value, CancellationToken ct = default);

    /// <summary>
    /// Deletes a domain object associated with a domain entity.
    /// </summary>
    /// <param name="entityId">The identifier of the domain entity.</param>
    /// <param name="label">The label of the domain object.</param>
    /// <param name="capabilityIdentifier">The capability identifier of the domain object.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
    Task<bool> DeleteDomainObjectAsync(Guid entityId, string label, string capabilityIdentifier, CancellationToken ct = default);
}