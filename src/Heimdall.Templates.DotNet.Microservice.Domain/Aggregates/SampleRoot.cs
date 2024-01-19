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

        public ValueTask AddSampleItem(SampleItem sampleItem)
        {
            _sampleItems.Add(sampleItem);

            var evt = new SampleItemAddedEvent(this, sampleItem);

            AddDomainEvent(evt);

            return ValueTask.CompletedTask;
        }

        public ValueTask AddSampleItem(IEnumerable<SampleItem> sampleItem)
        {
            foreach(var item in sampleItem){
                _sampleItems.Add(item);
            }

            return ValueTask.CompletedTask;
        }

        public ValueTask RemoveSampleItem(SampleItem sampleItem)
        {
            _sampleItems.Remove(sampleItem);

            var evt = new SampleItemRemovedEvent(this, sampleItem);

            AddDomainEvent(evt);

            return ValueTask.CompletedTask;
        }

        public ValueTask RemoveSampleItem(IEnumerable<SampleItem> sampleItem)
        {
            foreach (var item in sampleItem)
            {
                RemoveSampleItem(item);
            }

            return ValueTask.CompletedTask;
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}