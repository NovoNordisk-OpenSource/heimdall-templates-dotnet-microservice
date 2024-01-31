namespace Heimdall.Templates.DotNet.Microservice.Application.Mapping.Converters;

public class IIntegrationEventToDomainEntityConverter(IMapper mapper) : ITypeConverter<IIntegrationEvent, DomainEntity>
{
    public readonly IMapper _mapper = mapper;

    /// <summary>
    /// Converts an externally mutated domain entity integration event to a domain entity.
    /// </summary>
    /// <param name="source">The integration event to convert.</param>
    /// <param name="destination">The destination domain entity.</param>
    /// <param name="context">The resolution context.</param>
    /// <returns>The converted domain entity.</returns>
    public DomainEntity Convert(IIntegrationEvent source, DomainEntity destination, ResolutionContext context)
    {
        // TODO: Implement conversion logic.
        return destination;
    }
}
