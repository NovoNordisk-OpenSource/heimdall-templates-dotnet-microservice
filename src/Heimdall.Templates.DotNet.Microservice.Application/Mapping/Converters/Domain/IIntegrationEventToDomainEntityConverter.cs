namespace Heimdall.Templates.DotNet.Microservice.Application.Mapping.Converters.Domain;

public class IIntegrationEventToDomainEntityConverter(IMapper mapper, IDomainService domainService) : ITypeConverter<IIntegrationEvent, DomainEntity>
{
    public readonly IMapper _mapper = mapper;

    public readonly IDomainService _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));

    /// <summary>
    /// Converts an externally mutated domain entity integration event to a domain entity.
    /// </summary>
    /// <param name="source">The integration event to convert.</param>
    /// <param name="destination">The destination domain entity.</param>
    /// <param name="context">The resolution context.</param>
    /// <returns>The converted domain entity.</returns>
    public DomainEntity Convert(IIntegrationEvent source, DomainEntity destination, ResolutionContext context)
    {
        // Simplistic conversion logic
        JsonElement? payload;

        if (source?.Payload?.ValueKind == JsonValueKind.Object)
        {
            payload = source.Payload;
        }
        else
        {
            switch (source?.Payload?.ValueKind)
            {
                case JsonValueKind.String:
                    var rawText = source.Payload.Value.GetRawText();
                    var cleanedText = rawText[1..^1].Replace("\\", "");

                    payload = JsonDocument.Parse(cleanedText).RootElement;

                    break;
                default:
                    throw new ApplicationFacadeException($"Unsupported ValueKind: {source?.Payload?.ValueKind}");
            }
        }

        if(Guid.TryParse(payload?.GetProperty("id").GetString(), out var entityId))
        {
            var getEntityTask = _domainService.GetDomainEntityByIdAsync(entityId);

            getEntityTask.Wait();

            destination = getEntityTask.Result ?? throw new ApplicationFacadeException($"Domain entity with id {entityId} not found.");

            // TODO: Map the integration event payload (JsonObject) to the domain entity (DomainEntity)
        }

        return destination;
    }
}
