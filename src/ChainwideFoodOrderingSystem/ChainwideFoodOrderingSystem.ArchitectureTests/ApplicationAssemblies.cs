using System.Reflection;
using ChainwideFoodOrderingSystem.Orders.Entity;
using ChainwideFoodOrderingSystem.Orders.UseCase.InputPort.CreateOrder;
using ChainwideFoodOrderingSystem.SeedWork.Entity;

namespace ChainwideFoodOrderingSystem.ArchitectureTests;

/// <summary>
///     應用程式組件配置
/// </summary>
public static class ApplicationAssemblies
{
    /// <summary>
    ///     SeedWork 組件，包含共用的基礎類別和接口
    /// </summary>
    public static Assembly SeedWorkAssembly => typeof(DomainEvent).Assembly;

    /// <summary>
    ///     訂單模塊的組件配置
    /// </summary>
    public static ModuleAssembly OrdersModule => new()
    {
        EntityLayerAssembly = typeof(Order).Assembly, 
        UseCaseLayerAssembly = typeof(ICreateOrderUseCase).Assembly
    };

    /// <summary>
    ///     所有模塊組件的列表
    /// </summary>
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

/// <summary>
///     模塊組件配置
/// </summary>
public class ModuleAssembly
{
    /// <summary>
    ///     Entity 層組件
    /// </summary>
    public Assembly EntityLayerAssembly { get; init; }

    /// <summary>
    ///     UseCase 層組件
    /// </summary>
    public Assembly UseCaseLayerAssembly { get; init; }
}