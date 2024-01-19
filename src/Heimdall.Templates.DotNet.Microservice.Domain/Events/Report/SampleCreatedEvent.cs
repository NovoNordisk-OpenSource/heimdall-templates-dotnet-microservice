using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;

namespace Heimdall.Templates.DotNet.Microservice.Domain.Events.Report
{
    public sealed class SampleCreatedEvent : SampleEvent
    {
        public SampleCreatedEvent(SampleRoot sampleRoot)
        {
            SampleRoot = sampleRoot;
        }
    }
}