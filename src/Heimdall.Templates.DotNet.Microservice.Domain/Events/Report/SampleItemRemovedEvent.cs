using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;

namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Report
{
    public sealed class SampleItemRemovedEvent : SampleEvent
    {
        public SampleItem SampleItem { get; private set; }

        public SampleItemRemovedEvent(SampleRoot sampleRoot, SampleItem sampleItem)
        {
            SampleRoot = sampleRoot;
            SampleItem = sampleItem;
        }
    }
}