namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public sealed class GetDomainEntityByDateRangeCommand : ICommand<IEnumerable<DomainEntity>>
{
    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    [JsonConstructor]
    public GetDomainEntityByDateRangeCommand(DateTime startDate, DateTime? endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }
}