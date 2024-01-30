namespace Heimdall.Templates.DotNet.Microservice.Domain.UnitTest.Services;

public class CostServiceTests
{
    [Fact]
    public void CanBeConstructed()
    {
        //Arrange
        DomainService sut;
        var mockRepository = new Mock<IDomainEntityRepository>();

        //Act
        sut = new DomainService(mockRepository.Object);

        //Assert
        Assert.NotNull(sut);

        Mock.VerifyAll();
    }

    [Fact]
    public async Task CanAddDomainEntity()
    {
        //Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockRepository = new Mock<IDomainEntityRepository>();
        var fakeAggregate = new DomainEntity();

        mockUnitOfWork.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));
        mockRepository.SetupGet(m => m.UnitOfWork).Returns(mockUnitOfWork.Object);
        mockRepository.Setup(m => m.Add(It.IsAny<DomainEntity>())).Returns(fakeAggregate);

        var sut = new DomainService(mockRepository.Object);

        //Act
        var result = await sut.AddDomainEntityAsync(new[] { new DomainObject("a", "b", "c") });

        //Assert
        Assert.NotNull(result);

        Mock.VerifyAll();
    }

    [Fact]
    public async Task CanDeleteDomainEntity()
    {
        //Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockRepository = new Mock<IDomainEntityRepository>();
        var fakeAggregate = new DomainEntity();

        mockUnitOfWork.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));
        mockRepository.SetupGet(m => m.UnitOfWork).Returns(mockUnitOfWork.Object);
        mockRepository.Setup(m => m.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(fakeAggregate));
        mockRepository.Setup(m => m.Delete(It.IsAny<DomainEntity>()));

        var sut = new DomainService(mockRepository.Object);

        //Act
        await sut.DeleteDomainEntityAsync(Guid.NewGuid());

        //Assert
        Mock.VerifyAll();
    }

    [Fact]
    public async Task CanDeleteDomainObject()
    {
        //Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockRepository = new Mock<IDomainEntityRepository>();
        var fakeAggregate = new DomainEntity();

        mockUnitOfWork.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(1));
        mockRepository.SetupGet(m => m.UnitOfWork).Returns(mockUnitOfWork.Object);
        mockRepository.Setup(m => m.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(fakeAggregate));
        mockRepository.Setup(m => m.Delete(It.IsAny<DomainEntity>()));

        var sut = new DomainService(mockRepository.Object);

        //Act
        await sut.DeleteDomainObjectAsync(Guid.NewGuid(), "a", "b");

        //Assert
        Mock.VerifyAll();
    }
}