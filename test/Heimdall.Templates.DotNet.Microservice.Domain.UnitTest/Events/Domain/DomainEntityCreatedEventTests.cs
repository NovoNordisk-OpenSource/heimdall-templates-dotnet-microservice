namespace Heimdall.Templates.DotNet.Microservice.Domain.UnitTest.Events.Domain;

public class DomainEntityCreatedEventTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        DomainEntityCreatedEvent sut;

        //Act
        sut = new DomainEntityCreatedEvent(null);

        //Assert
        Assert.NotNull(sut);
        Assert.True(sut.Entity == null);
    }

    [Fact]
    public void AreNotEqual()
    {
        //Arrange
        var domainEntity = new DomainEntity();
        var sut = new DomainEntityCreatedEvent(domainEntity);

        //Act
        var anotherEvent = new DomainEntityCreatedEvent(domainEntity);

        //Assert
        Assert.True(sut.Entity == domainEntity);
        Assert.True(anotherEvent.Entity == domainEntity);
        Assert.False(sut.Equals(domainEntity));
    }
}