namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.EntityFramework;

using BeHeroes.CodeOps.Abstractions.Data;
using BeHeroes.CodeOps.Infrastructure.EntityFramework;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

/// <summary>
/// Represents the application context for the Entity Framework.
/// </summary>
public class ApplicationContext : EntityContext
{
    /// <summary>
    /// Gets or sets the DbSet for the domain entities.
    /// </summary>
    public virtual DbSet<DomainEntity> Entities { get; set; }

    /// <summary>
    /// Gets or sets the DbSet for the domain objects.
    /// </summary>
    public virtual DbSet<DomainObject> Objects { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
    /// </summary>
    public ApplicationContext()
    { }

    #pragma warning disable CS8625
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationContext"/> class with the specified options, mediator, and seed data.
    /// </summary>
    /// <param name="options">The DbContext options.</param>
    /// <param name="mediator">The mediator instance.</param>
    /// <param name="seedData">The seed data for the context.</param>
    public ApplicationContext(DbContextOptions options, IMediator mediator = default, IDictionary<Type, IEnumerable<IView>> seedData = default) : base(options)
    {

    }
    #pragma warning restore CS8625
}
