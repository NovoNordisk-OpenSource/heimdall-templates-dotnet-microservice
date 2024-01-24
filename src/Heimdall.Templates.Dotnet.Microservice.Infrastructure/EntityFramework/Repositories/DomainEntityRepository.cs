using BeHeroes.CodeOps.Infrastructure.EntityFramework.Repositories;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.EntityFramework.Repositories
{
    public class DomainEntityRepository : EntityFrameworkRepository<DomainEntity, ApplicationContext>, IDomainEntityRepository
    {
        public DomainEntityRepository(ApplicationContext context) : base(context)
        {
        }

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

        public async Task<DomainEntity> GetAsync(Guid entityId, CancellationToken ct = default)
        {
            var entity = await _context.Entities.FindAsync(entityId, ct);

            if (!entity?.Equals(null) == true)
            {
                var entry = _context.Entry(entity);

                if (!entry?.Equals(null) == true)
                {
                    await entry.Reference(o => o.Objects).LoadAsync(ct);
                }
            }

            return entity;
        }
    }
}