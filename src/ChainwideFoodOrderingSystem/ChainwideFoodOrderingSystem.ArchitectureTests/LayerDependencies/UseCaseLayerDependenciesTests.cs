using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ChainwideFoodOrderingSystem.ArchitectureTests.LayerDependencies;


public class UseCaseLayerDependenciesTests
{
    private static readonly Architecture ProjectArchitecture = CleanArchitectureSetup.ArchitectureForTesting;

    /// <summary>
    /// UseCase 層應該只依賴於 SeedWork 類別庫、Entity 層和 System 命名空間
    /// </summary>
    [Fact]
    public void UseCaseLayer_Should_Only_Depend_On_SeedWork_Entity_And_System_Namespaces()
    {
        foreach (var moduleAssemblies in ProjectAssemblyConfiguration.AllModuleAssemblies.Values)
        {
            IArchRule rule = Types()
                .That().ResideInAssembly(moduleAssemblies.UseCaseLayerAssembly)
                .As("UseCaseLayer")
                .Should().OnlyDependOnTypesThat()
                .ResideInAssembly(moduleAssemblies.EntityLayerAssembly)
                .As("EntityLayer")
                .OrShould().ResideInAssembly(ProjectAssemblyConfiguration.SeedWorkAssembly)
                .OrShould().ResideInNamespace("System.*", true)
                .Because("UseCase 層應該只依賴於 SeedWork 類別庫、Entity 層和 System 命名空間中的類型");

            rule.Check(ProjectArchitecture);
        }
    }
}