using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ChainwideFoodOrderingSystem.ArchitectureTests.LayerDependencies;

public class EntityLayerDependenciesTests
{
    private static readonly Architecture Architecture = ArchitectureTestSetup.Architecture;


    /// <summary>
    /// Entity 層不應依賴 UseCase 層或其他層，僅依賴 SeedWork 類別庫
    /// </summary>
    [Fact]
    public void EntityLayer_Should_Not_Depend_On_UseCase_Or_Other_Layers()
    {
        IArchRule rule = Types()
            .That().ResideInAssembly(ArchitectureTestSetup.Orders.EntityLayerAssembly)
            .Should().OnlyDependOnTypesThat().ResideInAssembly(ArchitectureTestSetup.SeedWorkAssembly)
            .OrShould().ResideInNamespace("System.*", true);

        rule.Check(Architecture);
    }

}