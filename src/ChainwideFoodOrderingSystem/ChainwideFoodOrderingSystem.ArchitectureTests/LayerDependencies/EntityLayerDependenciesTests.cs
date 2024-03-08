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
        foreach (var moduleAssemblies in ApplicationAssemblies.AllModuleAssemblies)
        {
            IArchRule rule = Types()
                .That().ResideInAssembly(moduleAssemblies.EntityLayerAssembly)
                .Should().OnlyDependOnTypesThat()
                .ResideInAssembly(ApplicationAssemblies.SeedWorkAssembly)
                .OrShould().ResideInNamespace("System.*", true)
                .Because("Entity 層應該只依賴於 SeedWork 類別庫和 System 命名空間中的類型");

            rule.Check(ProjectArchitecture);
        }
    }
}