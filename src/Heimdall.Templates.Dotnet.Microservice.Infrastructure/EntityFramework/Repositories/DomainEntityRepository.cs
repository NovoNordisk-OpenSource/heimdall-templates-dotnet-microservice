namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.EntityFramework.Repositories;

using BeHeroes.CodeOps.Infrastructure.EntityFramework.Repositories;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

/// <summary>
/// Represents a repository for managing <see cref="DomainEntity"/> entities in the database.
/// </summary>
public class DomainEntityRepository : EntityFrameworkRepository<DomainEntity, ApplicationContext>, IDomainEntityRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainEntityRepository"/> class.
    /// </summary>
    /// <param name="context">The application context.</param>
    public DomainEntityRepository(ApplicationContext context) : base(context)
    {
    }

    /// <summary>
    /// Retrieves a collection of <see cref="DomainEntity"/> entities from the database asynchronously based on the specified filter.
    /// </summary>
    /// <param name="filter">The filter expression.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of <see cref="DomainEntity"/> entities.</returns>
    public override async Task<IEnumerable<DomainEntity>> GetAsync(Expression<Func<DomainEntity, bool>> filter, CancellationToken ct = default)
    {
        return await Task.Factory.StartNew(() =>
        {
            return _context.Entities.AsQueryable()
                                        .AsNoTracking()
                                        .Where(filter)
                                        .Include(i => i.Objects)
                                        .AsEnumerable();
        }, ct);
    }

    /// <summary>
    /// Retrieves a <see cref="DomainEntity"/> entity from the database asynchronously based on the specified entity ID.
    /// </summary>
    /// <param name="entityId">The entity ID.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="DomainEntity"/> entity, or null if not found.</returns>
    public async Task<DomainEntity?> GetAsync(Guid entityId, CancellationToken ct = default)
    {
        var entity = await _context.Entities.FindAsync(entityId, ct);

        if (entity is not null)
        {
            var entry = _context.Entry(entity);

            if (entry != null)
            {
                await entry.Reference(o => o.Objects).LoadAsync(ct);
            }
        }

        return entity;
    }
}