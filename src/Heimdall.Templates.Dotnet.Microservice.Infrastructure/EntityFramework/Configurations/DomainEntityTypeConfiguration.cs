using Heimdall.Templates.DotNet.Microservice.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.EntityFramework.Configurations
{
    public class DomainEntityTypeConfiguration : IEntityTypeConfiguration<DomainEntity>
    {
        public void Configure(EntityTypeBuilder<DomainEntity> builder)
        {
            builder.Ignore(v => v.DomainEvents);
            builder.Property(v => v.Id).IsRequired();
            builder.Property(v => v.Created);
            builder.HasKey(v => v.Id);
            builder.ToTable("DomainEntity");

            builder.OwnsMany(
            p => p.Objects, a =>
            {
                a.WithOwner().HasForeignKey("OwnerId");
                a.Property<Guid>("Id");
                a.HasKey("Id");
            });
        }
    }
}