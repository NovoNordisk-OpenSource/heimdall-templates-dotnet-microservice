namespace Heimdall.Templates.DotNet.Microservice.Application.Mapping.Converters;

public class IIntegrationEventToICommandConverter(IMapper mapper) : ITypeConverter<IIntegrationEvent, ICommand<IAggregateRoot>>
{
    public readonly IMapper _mapper = mapper;

    public ICommand<IAggregateRoot> Convert(IIntegrationEvent source, ICommand<IAggregateRoot> destination, ResolutionContext context)
    {
        return _mapper.Map(source, destination);
    }
}
