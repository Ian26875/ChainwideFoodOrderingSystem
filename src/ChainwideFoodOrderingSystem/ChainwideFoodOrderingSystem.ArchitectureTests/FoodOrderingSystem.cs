using System.Reflection;
using ChainwideFoodOrderingSystem.Orders.Entity;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;

namespace ChainwideFoodOrderingSystem.ArchitectureTests;

public class FoodOrderingSystem
{
    public class OrderingLayers
    {
        public static Assembly EntityLayerAssembly => typeof(Order).Assembly;
        public static Assembly UseCaseLayerAssembly => typeof(ICreateOrderUseCase).Assembly;
    }
}