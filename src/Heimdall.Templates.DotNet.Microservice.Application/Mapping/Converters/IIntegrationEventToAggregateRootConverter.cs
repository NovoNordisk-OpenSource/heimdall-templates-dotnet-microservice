namespace Heimdall.Templates.DotNet.Microservice.Application.Mapping.Converters;

public class IIntegrationEventToAggregateRootConverter(IMapper mapper) : ITypeConverter<IIntegrationEvent, IAggregateRoot>
{
    public readonly IMapper _mapper = mapper;

    public IAggregateRoot Convert(IIntegrationEvent source, IAggregateRoot destination, ResolutionContext context)
    {
        return source.Type switch
        {
            "external_update_to_domain_entity" => _mapper.Map<DomainEntity>(source),
            _ => throw new NotSupportedException($"The integration event type {source.Type} is not supported.")
        };
    }
}
