namespace Heimdall.Templates.DotNet.Microservice.Application.Mapping.Profiles;

/// <summary>
///     Represents the default AutoMapper profile for mapping entities in the application.
/// </summary>
public sealed class DefaultProfile : Profile
{
    public DefaultProfile()
    {
        CreateMap<IIntegrationEvent, IAggregateRoot>()
        .ConvertUsing<IIntegrationEventToAggregateRootConverter>();

        CreateMap<IAggregateRoot, ICommand<IAggregateRoot>>()
        .ConvertUsing<AggregateRootToCommandConverter>();
    }
}