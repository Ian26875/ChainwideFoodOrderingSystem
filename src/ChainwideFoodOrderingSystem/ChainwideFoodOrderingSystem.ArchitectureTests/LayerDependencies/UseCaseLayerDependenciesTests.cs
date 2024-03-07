using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ChainwideFoodOrderingSystem.ArchitectureTests.LayerDependencies;

public class UseCaseLayerDependenciesTests
{
    private static readonly Architecture Architecture = ArchitectureTestSetup.Architecture;


    
    /// <summary>
    /// UseCase 層只能依賴 Entity 層與 Seedwork 類別庫
    /// </summary>
    [Fact]
    public void UseCaseLayer_Should_Only_Depend_On_Entity_And_SeedWork_Layers()
    {
        IArchRule rule = Types()
            .That().ResideInAssembly(ArchitectureTestSetup.Orders.UseCaseLayerAssembly)
            .Should().OnlyDependOnTypesThat()
            .ResideInAssembly(ArchitectureTestSetup.Orders.EntityLayerAssembly);
        
        rule.Check(Architecture);
    }
}