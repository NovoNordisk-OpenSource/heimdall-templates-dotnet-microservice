using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;

namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Report
{
    public sealed class SampleItemAddedEvent : SampleEvent
    {
        public SampleItem SampleItem { get; private set; }

        public SampleItemAddedEvent(SampleRoot sampleRoot, SampleItem sampleItem)
        {
            SampleRoot = sampleRoot;
            SampleItem = sampleItem;
        }
    }
}