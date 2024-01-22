using BeHeroes.CodeOps.Abstractions.Data;
using BeHeroes.CodeOps.Infrastructure.EntityFramework;
using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Heimdall.Templates.DotNet.Microservice.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.EntityFramework
{
    public class ApplicationContext : EntityContext
    {
        public virtual DbSet<DomainEntity> Entities { get; set; }

        public virtual DbSet<DomainObject> Objects { get; set; }

        public ApplicationContext()
        { }

        public ApplicationContext(DbContextOptions options, IMediator mediator = default, IDictionary<Type, IEnumerable<IView>> seedData = default) : base(options)
        {

        }
    }
}
