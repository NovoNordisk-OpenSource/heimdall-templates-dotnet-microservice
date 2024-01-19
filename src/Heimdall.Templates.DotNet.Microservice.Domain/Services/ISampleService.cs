using BeHeroes.CodeOps.Abstractions.Services;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microservice.Domain.Services
{
    public interface ISampleService : IService
    {
        Task<IEnumerable<SampleRoot>> GetSampleByCapabilityIdentifierAsync(string capabilityIdentifier, CancellationToken ct = default);

        Task<IEnumerable<SampleRoot>> GetSampleByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken ct = default);

        Task<SampleRoot> AddSampleAsync(IEnumerable<SampleItem> sampleItems, CancellationToken ct = default);

        Task<SampleRoot> UpdateSampleAsync(SampleRoot sample, CancellationToken ct = default);

        Task<bool> DeleteReportAsync(Guid sampleId, CancellationToken ct = default);

        Task<SampleItem> AddOrUpdateSampleItemAsync(Guid sampleItemId, string capabilityIdentifier, string label, string value, CancellationToken ct = default);

        Task<bool> DeleteSampleItemAsync(Guid sampleId, string label, string capabilityIdentifier, CancellationToken ct = default);
    }
}