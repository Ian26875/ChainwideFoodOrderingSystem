using System.Reflection;
using ChainwideFoodOrderingSystem.Orders.Entity;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;
using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.ArchitectureTests;

public static class ApplicationAssemblies
{
    public static Assembly SeedWorkAssembly => typeof(DomainEvent).Assembly;

    public static ModuleAssembly OrdersModule => new ModuleAssembly
    {
        EntityLayerAssembly = typeof(Order).Assembly,
        UseCaseLayerAssembly = typeof(ICreateOrderUseCase).Assembly
    };
    
    
    public static List<ModuleAssembly> AllModuleAssemblies
    {
        get
        {
            var modulesAssemblies = new List<ModuleAssembly>
            {
                OrdersModule
            };

            return modulesAssemblies;
        }
    }
}

public class ModuleAssembly
{
    public Assembly EntityLayerAssembly { get; set; }
    public Assembly UseCaseLayerAssembly { get; set; }
}