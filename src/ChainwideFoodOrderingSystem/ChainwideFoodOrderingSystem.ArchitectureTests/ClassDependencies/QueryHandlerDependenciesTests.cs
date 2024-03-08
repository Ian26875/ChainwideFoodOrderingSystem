using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Query;
using static ArchUnitNET.Fluent.ArchRuleDefinition;


namespace ChainwideFoodOrderingSystem.ArchitectureTests.ClassDependencies;

public class QueryHandlerDependenciesTests
{
    private static readonly Architecture Architecture = CleanArchitectureSetup.ArchitectureForTesting;

    [Fact]
    public void QueryHandlers_Should_Not_Depend_On_Forbidden_Interfaces()
    {
        IArchRule rule = Types()
            .That().ImplementInterface(typeof(IQueryHandler<,>))
            .Should().NotDependOnAnyTypesThat()
            .ImplementInterface(typeof(IInquiry<,>))
            .OrShould().ImplementInterface(typeof(IQueryHandler<,>))
            .OrShould().ImplementInterface(typeof(ICommandHandler<,>))
            .Because("QueryHandler should not depend on IInquiry, IQueryHandler, or ICommandHandler interfaces.");

        rule.Check(Architecture);
    }
    
}