namespace Heimdall.Templates.DotNet.Microservice.Application.Commands.Domain;

using BeHeroes.CodeOps.Abstractions.Commands;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// Represents a command to retrieve domain entities within a specified date range.
/// </summary>
public sealed class GetDomainEntityByDateRangeCommand : ICommand<IEnumerable<DomainEntity>>
{
    /// <summary>
    /// Gets or sets the start date of the date range.
    /// </summary>
    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; init; }

    /// <summary>
    /// Gets or sets the end date of the date range. Can be null if only the start date is considered.
    /// </summary>
    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetDomainEntityByDateRangeCommand"/> class.
    /// </summary>
    /// <param name="startDate">The start date of the date range.</param>
    /// <param name="endDate">The end date of the date range. Can be null if only the start date is considered.</param>
    [JsonConstructor]
    public GetDomainEntityByDateRangeCommand(DateTime startDate, DateTime? endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }
}