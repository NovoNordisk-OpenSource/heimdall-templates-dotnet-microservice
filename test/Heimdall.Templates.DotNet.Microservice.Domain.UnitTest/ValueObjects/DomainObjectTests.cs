namespace Heimdall.Templates.DotNet.Microservice.Domain.UnitTest.ValueObjects;

public class DomainObjectTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        DomainObject sut;

        //Act
        sut = new DomainObject("label", "value", "identifier");

        //Assert
        Assert.NotNull(sut);
        Assert.Equal("identifier", sut.CapabilityIdentifier);
        Assert.Equal("label", sut.Label);
        Assert.Equal("value", sut.Value);
    }

    [Fact]
    public void CanBeSerialized()
    {
        //Arrange
        var sut = new DomainObject("label", "value", "identifier");

        //Act
        var payload = JsonSerializer.Serialize(sut, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        //Assert
        Assert.NotNull(JsonDocument.Parse(payload));
    }

    [Fact]
    public void CanBeDeserialized()
    {
        //Arrange
        DomainObject sut;

        //Act
        sut = JsonSerializer.Deserialize<DomainObject>("{\"capabilityIdentifier\":\"identifier\",\"value\":\"value\",\"label\":\"label\"}");

        //Assert
        Assert.NotNull(sut);
        Assert.Equal("identifier", sut.CapabilityIdentifier);
        Assert.Equal("label", sut.Label);
        Assert.Equal("value", sut.Value);
    }
}