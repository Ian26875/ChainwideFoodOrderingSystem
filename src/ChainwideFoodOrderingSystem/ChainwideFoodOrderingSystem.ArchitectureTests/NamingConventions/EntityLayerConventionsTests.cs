//add a using directive to ArchUnitNET.Fluent.ArchRuleDefinition to easily define ArchRules
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using ChainwideFoodOrderingSystem.SeedWork.Entity;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ChainwideFoodOrderingSystem.ArchitectureTests.NamingConventions;

/// <summary>
/// UseCase Layer 命名慣例與介面
/// </summary>
public class EntityLayerConventionsTests
{
    private static readonly Architecture Architecture = ArchitectureTestSetup.Architecture;
                     
    
    
    
    /// <summary>
    /// 強制所有 Entity 層的 DomainEvents 資料夾中的類字尾必須是 Event
    /// </summary>
    [Fact]
    public void All_DomainEvents_Should_End_With_Event()
    {
        IArchRule rule = Classes()
            .That().ResideInNamespace(".*\\.Entity.DomainEvents", true)
            .Should().HaveNameEndingWith("Event");

        rule.Check(Architecture);
    }
}