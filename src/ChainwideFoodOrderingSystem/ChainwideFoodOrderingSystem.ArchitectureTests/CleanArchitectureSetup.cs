using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using Assembly = System.Reflection.Assembly;

namespace ChainwideFoodOrderingSystem.ArchitectureTests;

/// <summary>
///     乾淨架構配置類
/// </summary>
public static class CleanArchitectureSetup
{
    /// <summary>
    ///     專案架構定義，用於架構測試
    /// </summary>
    public static Architecture ArchitectureForTesting
    {
        get
        {
            var assemblies = new List<Assembly>
            {
                ProjectAssemblyConfiguration.SeedWorkAssembly
            };

            assemblies.AddRange(UseCaseLayerAssemblies);
            assemblies.AddRange(EntityLayerAssemblies);

            return new ArchLoader().LoadAssemblies(assemblies.ToArray()).Build();
        }
    }

    /// <summary>
    ///     UseCase 層的組件列表
    /// </summary>
    public static Assembly[] UseCaseLayerAssemblies
    {
        get
        {
            return ProjectAssemblyConfiguration.AllModuleAssemblies.Values
                                                            .Select(m => m.UseCaseLayerAssembly)
                                                            .ToArray();
        }
    }

    /// <summary>
    ///     Entity 層的組件列表
    /// </summary>
    public static Assembly[] EntityLayerAssemblies
    {
        get
        {
            return ProjectAssemblyConfiguration.AllModuleAssemblies.Values
                                                            .Select(m => m.EntityLayerAssembly)
                                                            .ToArray();
        }
    }
}