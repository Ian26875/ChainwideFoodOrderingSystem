using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using ChainwideFoodOrderingSystem.SeedWork.Entity;
using ChainwideFoodOrderingSystem.SeedWork.UseCase;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Query;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ChainwideFoodOrderingSystem.ArchitectureTests.NamingConventions;



public class LayerNamingConventionsTests
{
    private static readonly Architecture Architecture = ArchitectureTestSetup.Architecture;

    
    [Fact]
    public void Entity_Layer_Classes_Should_Reside_In_Entity_Namespace()
    {
        IArchRule rule = Classes()
            .That().AreAssignableTo(typeof(AggregateRoot<>))
            .Or().AreAssignableTo(typeof(Entity<>))
            .Or().AreAssignableTo(typeof(ValueObject<>))
            .Should().ResideInNamespace(".*\\.Entity", true);

        rule.Check(Architecture);
    }

    [Fact]
    public void UseCase_Layer_Classes_Should_Reside_In_UseCase_Namespace()
    {
        IArchRule rule = Classes()
            .That().AreAssignableTo(typeof(IUseCase<,>))
            .Should().ResideInNamespace(".*\\.UseCase", true);

        rule.Check(Architecture);
    }
    
    //[Fact]
    public void Persistence_Layer_Classes_Should_Reside_In_Persistence_Namespace()
    {
        IArchRule rule = Classes()
            .That().AreAssignableTo(typeof(IRepository<,>))
            .Or().AreAssignableTo(typeof(IArchive<,>))
            .Or().AreAssignableTo(typeof(IInquiry<,>))
            .Should().ResideInNamespace(@".*\.Persistence.*\", true);

        rule.Check(Architecture);
    }
    
    
}