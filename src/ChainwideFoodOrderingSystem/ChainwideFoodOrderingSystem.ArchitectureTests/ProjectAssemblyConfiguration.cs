using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace ChainwideFoodOrderingSystem.ArchitectureTests;

/// <summary>
///     應用程式組件配置
/// </summary>
public static class ProjectAssemblyConfiguration
{
    static ProjectAssemblyConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("architectureSettings.json")
            .Build();

        SeedWorkAssembly = LoadAssembly(configuration["ApplicationAssemblies:SeedWork"]);

        var modulesSection = configuration.GetSection("ApplicationAssemblies:Modules");
        foreach (var moduleSection in modulesSection.GetChildren())
        {
            var moduleAssembly = new ModuleAssembly
            {
                EntityLayerAssembly = LoadAssembly(moduleSection["EntityLayer"]),
                UseCaseLayerAssembly = LoadAssembly(moduleSection["UseCaseLayer"])
            };
            AllModuleAssemblies.Add(moduleSection.Key, moduleAssembly);
        }
    }
    
    private static Assembly LoadAssembly(string assemblyName)
    {
        return Assembly.Load(new AssemblyName(assemblyName));
    }

    /// <summary>
    ///     SeedWork 組件，包含共用的基礎類別和接口
    /// </summary>
    public static Assembly SeedWorkAssembly { get; private set; }
    
    /// <summary>
    ///     所有模塊組件的列表
    /// </summary>
    public static Dictionary<string, ModuleAssembly> AllModuleAssemblies { get; } = new();
    
    
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