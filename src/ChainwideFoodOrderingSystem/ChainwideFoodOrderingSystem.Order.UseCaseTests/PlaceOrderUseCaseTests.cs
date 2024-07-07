using AutoFixture.Xunit2;
using ChainwideFoodOrderingSystem.Order.UseCaseTests.TestCustomizations;
using ChainwideFoodOrderingSystem.Orders.UseCase;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;
using ChainwideFoodOrderingSystem.Orders.UseCase.OutputPort;
using ChainwideFoodOrderingSystem.SeedWork.Entity;
using ChainwideFoodOrderingSystem.SeedWork.UseCase;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.DomainEvents;
using FluentAssertions;
using Moq;

namespace ChainwideFoodOrderingSystem.Order.UseCaseTests;

public class PlaceOrderUseCaseTests
{

    [Theory]
    [AutoMoqData]
    public async Task Handle_WhenInputIsNull_ThrowArgumentException(PlaceOrderUseCase sut)
    {
        // arrange
        PlaceOrderInput input = null;

        // act
        Func<Task> func = async () => await sut.ExecuteAsync(input);

        // assert
        await func.Should().ThrowAsync<ArgumentNullException>();
    }
    
    
    [Theory]
    [AutoMoqData]
    public async Task ExecuteAsync_CreatesOrderAndAddsOrderItems(
        PlaceOrderInput input,
        [Frozen] Mock<IOrderRepository> mockOrderRepository,
        [Frozen] Mock<IEventBus> mockEventBus,
        PlaceOrderUseCase sut)
    {
        // Arrange
        mockOrderRepository.Setup(x => x.SaveAsync(It.IsAny<Orders.Entity.Order>()))
                           .ReturnsAsync((Orders.Entity.Order order) => order);

        // Act
        var actual = await sut.ExecuteAsync(input);

        // Assert
        mockOrderRepository.Verify(x => x.SaveAsync(It.IsAny<Orders.Entity.Order>()), Times.Once);
        mockEventBus.Verify(x => x.PublishAsync(It.IsAny<DomainEvent>()), Times.AtLeastOnce);
        actual.Should().NotBeNull();
        actual.ExitCode.Should().Be(ExitCode.Success);
    }
}