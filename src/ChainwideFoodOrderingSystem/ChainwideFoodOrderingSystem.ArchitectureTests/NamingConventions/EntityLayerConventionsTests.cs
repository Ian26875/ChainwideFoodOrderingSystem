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
    private static readonly Architecture ProjectArchitecture = CleanArchitectureConfiguration.ProjectArchitecture;
    
    /// <summary>
    /// 強制所有 Entity 層的 DomainEvents 資料夾中的類字尾必須是 Event
    /// </summary>
    [Fact]
    public void All_DomainEvents_Should_End_With_Event()
    {
        foreach (var entityLayerAssembly in CleanArchitectureConfiguration.EntityLayers)
        {
            IArchRule rule = Classes()
                .That().ResideInAssembly(entityLayerAssembly)
                .And().ResideInNamespace(".*\\.Entity.DomainEvents", true)
                .Should().HaveNameEndingWith("Event")
                .Because("所有的領域事件必須放在DomainEvents資料夾底下，且必須以'Event'作為命名字尾。");

            rule.Check(ProjectArchitecture);
        }
    }
}