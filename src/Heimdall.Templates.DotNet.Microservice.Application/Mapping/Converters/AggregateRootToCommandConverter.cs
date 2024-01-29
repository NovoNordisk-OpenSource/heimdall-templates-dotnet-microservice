namespace Heimdall.Templates.DotNet.Microservice.Application.Mapping.Converters;

public class AggregateRootToCommandConverter : ITypeConverter<IAggregateRoot, ICommand<IAggregateRoot>>
{
    public ICommand<IAggregateRoot> Convert(IAggregateRoot source, ICommand<IAggregateRoot> destination, ResolutionContext context)
    {
        // TODO: Finish mapping aggregate commands
        switch (source)
        {
            case DomainEntity entity:
                if (entity.Id == Guid.Empty)
                {
                    destination = new CreateDomainEntityCommand(entity.Objects);
                }
                else
                {
                    destination = new UpdateDomainEntityCommand(entity);
                }

                break;
            case null:
            default:
                throw new NotSupportedException($"The aggregate root type {source?.GetType().Name} is not supported.");
        }

        return destination;
    }
}