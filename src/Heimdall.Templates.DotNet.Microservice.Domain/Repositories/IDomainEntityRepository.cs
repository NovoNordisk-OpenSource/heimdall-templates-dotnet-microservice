namespace Heimdall.Templates.DotNet.Microservice.Domain.Repositories;

/// <summary>
///     Represents a repository for managing <see cref="DomainEntity" /> objects.
/// </summary>
public interface IDomainEntityRepository : IRepository<DomainEntity>
{
    /// <summary>
    ///     Retrieves a <see cref="DomainEntity" /> object asynchronously based on its ID.
    /// </summary>
    /// <param name="entityId">The ID of the entity to retrieve.</param>
    /// <param name="ct">The cancellation token (optional).</param>
    /// <returns>
    ///     A task representing the asynchronous operation that returns the retrieved <see cref="DomainEntity" /> object,
    ///     or null if not found.
    /// </returns>
    Task<DomainEntity?> GetAsync(Guid entityId, CancellationToken ct = default);
}