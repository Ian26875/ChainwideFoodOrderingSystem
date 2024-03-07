using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using ChainwideFoodOrderingSystem.SeedWork.Entity;
using static ArchUnitNET.Fluent.ArchRuleDefinition;


namespace ChainwideFoodOrderingSystem.ArchitectureTests.ClassEnforcements;


public class EntityLayerEnforcementTests
{
    private static readonly Architecture Architecture = CleanArchitectureConfiguration.ProjectArchitecture;

    
    /// <summary>
    /// 強制所有 Entity 層的 DomainEvents 資料夾中的類都必須繼承 DomainEvent
    /// </summary>
    [Fact]
    public void DomainEvents_In_EntityLayer_Should_Inherit_DomainEvent()
    {
        foreach (var entityLayerAssembly in CleanArchitectureConfiguration.EntityLayers)
        {
            IArchRule architectureRule = Classes()
                .That().ResideInAssembly(entityLayerAssembly)
                .And().ResideInNamespace(".*\\.Entity.DomainEvents", true)
                .Should().BeAssignableTo(typeof(DomainEvent))
                .Because("Entity 層中的 DomainEvents 應該繼承於 DomainEvent");;

            architectureRule.Check(Architecture);
        }
    }
    
    /// <summary>
    /// 強制所有 Entity 層的類別都必須繼承 AggregateRoot、Entity 或 ValueObject
    /// </summary>
    [Fact]
    public void Classes_In_EntityLayer_Should_Inherit_BaseTypes()
    {
        foreach (var entityLayerAssembly in CleanArchitectureConfiguration.EntityLayers)
        {
            IArchRule architectureRule = Classes()
                .That().ResideInAssembly(entityLayerAssembly)
                .Should().BeAssignableTo(typeof(AggregateRoot<>))
                .OrShould().BeAssignableTo(typeof(Entity<>))
                .OrShould().BeAssignableTo(typeof(ValueObject<>))
                .Because("Entity 層中的類別應該繼承於基本類型 AggregateRoot、Entity 或 ValueObject");

            architectureRule.Check(Architecture);
        }
    }

}