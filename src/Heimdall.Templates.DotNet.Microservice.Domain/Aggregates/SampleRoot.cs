using BeHeroes.CodeOps.Abstractions.Aggregates;
using BeHeroes.CodeOps.Abstractions.Entities;
using Heimdall.Templates.DotNet.Microservice.Domain.Events.Report;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Heimdall.Templates.DotNet.Microservice.Domain.Aggregates
{
    public sealed class SampleRoot : Entity<Guid>, IAggregateRoot
    {
        private readonly List<SampleItem> _sampleItems;

        private readonly DateTime _created = DateTime.UtcNow;

        public IEnumerable<SampleItem> SampleItems => _sampleItems.AsReadOnly();

        public DateTime Created => _created;

        public SampleRoot()
        {
            _sampleItems = new List<SampleItem>();

            var evt = new SampleCreatedEvent(this);

            AddDomainEvent(evt);
        }

        public SampleRoot(DateTime created) : this()
        {
            _created = created;
        }

        public void AddSampleItem(SampleItem sampleItem)
        {
            _sampleItems.Add(sampleItem);
        }

        public void AddSampleItem(IEnumerable<SampleItem> sampleItem)
        {
            _sampleItems.AddRange(sampleItem);
        }

        public void RemoveSampleItem(IEnumerable<SampleItem> sampleItems)
        {
            foreach (var item in sampleItems)
            {
                _sampleItems.Remove(item);
            }
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}