using BeHeroes.CodeOps.Abstractions.Repositories;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;

namespace Heimdall.Templates.DotNet.Microservice.Domain.Repositories
{
    public interface ISampleRepository : IRepository<SampleRoot>
    {
        Task<SampleRoot> GetAsync(Guid sampleItemId);
    }
}