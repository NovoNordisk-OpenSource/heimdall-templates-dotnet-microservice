namespace Heimdall.Templates.DotNet.Microservice.Application.UnitTest.Events.Domain;

public class DomainEntityCreatedEventHandlerTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockMediator = new Mock<IMediator>();
        var sut = new DomainEntityCreatedEventHandler(mockMapper.Object, mockMediator.Object);

        //Act
        var hashCode = sut.GetHashCode();

        //Assert
        Assert.NotNull(sut);
        Assert.Equal(hashCode, sut.GetHashCode());

        Mock.VerifyAll();
    }

    [Fact]
    public async Task CanHandleEvent()
    {
        //Arrange
        var mockMapper = new Mock<IMapper>();
        var mockMediator = new Mock<IMediator>();
        var sut = new DomainEntityCreatedEventHandler(mockMapper.Object, mockMediator.Object);

        //Act
        await sut.Handle(new DomainEntityCreatedEvent(new DomainEntity()));

        //Assert
        Mock.VerifyAll();
    }
}