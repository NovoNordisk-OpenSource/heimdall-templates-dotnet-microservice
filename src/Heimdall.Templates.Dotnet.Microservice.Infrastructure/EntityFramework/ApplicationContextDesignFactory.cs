namespace Heimdall.Templates.Dotnet.Microservice.Infrastructure.EntityFramework;

using BeHeroes.CodeOps.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public sealed class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var connection = new Npgsql.NpgsqlConnection("User ID=postgres;Password=local;Host=localhost;Port=5432;Database=postgres");

        connection.Open();

        var optionsBuilder = new DbContextOptionsBuilder<EntityContext>()
            .UseNpgsql(connection);

        return new ApplicationContext(optionsBuilder.Options);
    }
}