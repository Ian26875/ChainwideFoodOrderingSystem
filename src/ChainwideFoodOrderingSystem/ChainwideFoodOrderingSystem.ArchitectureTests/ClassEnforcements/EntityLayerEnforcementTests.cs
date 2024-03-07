using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using ChainwideFoodOrderingSystem.SeedWork.Entity;
using static ArchUnitNET.Fluent.ArchRuleDefinition;


namespace ChainwideFoodOrderingSystem.ArchitectureTests.ClassEnforcements;


public class EntityLayerEnforcementTests
{
    private static readonly Architecture Architecture = ArchitectureTestSetup.Architecture;

    /// <summary>
    /// 強制所有 Entity 層的 DomainEvents 資料夾中的類只有繼承 DomainEvent
    /// </summary>
    [Fact]
    public void All_DomainEvents_Should_Inherit_DomainEvent()
    {
        IArchRule rule = Classes()
            .That().ResideInNamespace(".*\\.Entity.DomainEvents", true)
            .Should().BeAssignableTo(typeof(DomainEvent));

        rule.Check(Architecture);
    }
    
    
    
}