namespace Heimdall.Templates.DotNet.Microservice.Application.Events.Domain;

using BeHeroes.CodeOps.Abstractions.Events;
using System;
using System.Text.Json;

public class DomainEntityCreatedIntegrationEvent : IIntegrationEvent
{
    public string Id { get; init; } = string.Empty;

    public string CorrelationId { get; init; } = string.Empty;

    public DateTime CreationDate { get; init; }

    public string SchemaVersion { get; init; } = string.Empty;

    public string Type { get; init; } = string.Empty;

    public JsonElement? Payload { get; init; }
}