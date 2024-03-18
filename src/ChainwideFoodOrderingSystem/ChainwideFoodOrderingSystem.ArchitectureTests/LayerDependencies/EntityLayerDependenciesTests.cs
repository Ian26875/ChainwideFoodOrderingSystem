using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;


namespace ChainwideFoodOrderingSystem.ArchitectureTests.LayerDependencies;

public class EntityLayerDependenciesTests
{
    private static readonly Architecture ProjectArchitecture = CleanArchitectureSetup.ArchitectureForTesting;

    
    /// <summary>
    /// Entity 層應該只依賴於 SeedWork 類別庫和 System 命名空間
    /// </summary>
    [Fact]
    public void EntityLayer_Should_Only_Depend_On_SeedWork_And_System_Namespaces()
    {
        foreach (var moduleAssemblies in ProjectAssemblyConfiguration.AllModuleAssemblies.Values)
        {
            IArchRule rule = Types()
                .That().ResideInAssembly(moduleAssemblies.EntityLayerAssembly)
                .As("EntityLayer")
                .Should().OnlyDependOnTypesThat()
                .ResideInAssembly(ProjectAssemblyConfiguration.SeedWorkAssembly)
                .As("SeedWorkLayer")
                .OrShould().ResideInNamespace("System.*", true)
                .Because("Entity 層應該只依賴於 SeedWork 類別庫和 System 命名空間中的類型");

            rule.Check(ProjectArchitecture);
        }
    }
    
    /// <summary>
    /// 測試 Entity 層不應該依賴於 UseCase 層
    /// </summary>
    [Fact]
    public void Entity_Layer_Should_Not_Depend_On_UseCase_Layer()
    {
        foreach (var moduleAssemblies in ProjectAssemblyConfiguration.AllModuleAssemblies.Values)
        {
            IArchRule rule = Types()
                .That().ResideInAssembly(moduleAssemblies.EntityLayerAssembly)
                .Should().NotDependOnAny(Types().That().ResideInAssembly(moduleAssemblies.UseCaseLayerAssembly))
                .Because("Entity 層不應該依賴於 UseCase 層");

            rule.Check(ProjectArchitecture);
        }
    }
}