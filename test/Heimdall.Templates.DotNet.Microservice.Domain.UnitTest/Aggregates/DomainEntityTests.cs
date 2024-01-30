namespace Heimdall.Templates.DotNet.Microservice.Domain.UnitTest.Aggregates;

public class DomainEntityTests
{
    [Fact]
    public void CanBeConstructed()
    {
        var sut = new DomainEntity();

        Assert.NotNull(sut);
        Assert.True(sut.DomainEvents.Count == 1);
        Assert.Contains(sut.DomainEvents, i => i is DomainEntityCreatedEvent);
    }

    [Fact]
    public void CanDetectValidConstruction()
    {
        //Arrange
        var sut = new DomainEntity();
        var validationCtx = new ValidationContext(this);

        //Act
        var validationResults = sut.Validate(validationCtx);

        //Assert
        Assert.True(!validationResults.Any());
        Assert.Contains(sut.DomainEvents, i => i is DomainEntityCreatedEvent);
    }
}