using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ChainwideFoodOrderingSystem.Orders.Entity;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;
using ChainwideFoodOrderingSystem.SeedWork.Entity;
using Assembly = System.Reflection.Assembly;

namespace ChainwideFoodOrderingSystem.ArchitectureTests;

public class ArchitectureTestSetup
{

    public static Assembly SeedWorkAssembly => typeof(DomainEvent).Assembly;
    
    public class Orders
    {
        public static Assembly EntityLayerAssembly => typeof(Order).Assembly;
        public static Assembly UseCaseLayerAssembly => typeof(ICreateOrderUseCase).Assembly;
    }


    public static readonly Architecture Architecture = new ArchLoader().LoadAssemblies
            (
                SeedWorkAssembly,
                Orders.EntityLayerAssembly,
                Orders.UseCaseLayerAssembly
            )
            .Build();
    
    
}