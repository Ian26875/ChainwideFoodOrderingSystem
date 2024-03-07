using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using Assembly = System.Reflection.Assembly;

namespace ChainwideFoodOrderingSystem.ArchitectureTests;

/// <summary>
/// 乾淨架構配置類
/// </summary>
public static class CleanArchitectureConfiguration
{
    /// <summary>
    /// 專案架構定義，用於架構測試
    /// </summary>
    public static Architecture ProjectArchitecture
    {
        get
        {
            var assemblies = new List<Assembly>
            {
                ApplicationAssemblies.SeedWorkAssembly
            };
            
            assemblies.AddRange(UseCaseLayers);    
            assemblies.AddRange(EntityLayers);
            
            return new ArchLoader().LoadAssemblies(assemblies.ToArray()).Build();
        }
    }

    /// <summary>
    /// UseCase 層的組件列表
    /// </summary>
    public static Assembly[] UseCaseLayers => ApplicationAssemblies.AllModuleAssemblies.Select(x => x.UseCaseLayerAssembly).ToArray();
    
    /// <summary>
    /// Entity 層的組件列表
    /// </summary>
    public static Assembly[] EntityLayers => ApplicationAssemblies.AllModuleAssemblies.Select(x => x.EntityLayerAssembly).ToArray();
}


