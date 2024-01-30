namespace Heimdall.Templates.DotNet.Microservice.Application.IntegrationTest.Fixtures;

public class ServiceProviderFixture : IDisposable
{
    public IServiceProvider Provider { get; init; }

    public ServiceProviderFixture()
    {
        var services = new ServiceCollection();

        services.AddApplication();

        Provider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
    }
}
