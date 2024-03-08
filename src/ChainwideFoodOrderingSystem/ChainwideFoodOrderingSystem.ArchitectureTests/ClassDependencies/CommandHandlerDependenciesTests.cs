using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using ChainwideFoodOrderingSystem.SeedWork.UseCase;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Query;
using static ArchUnitNET.Fluent.ArchRuleDefinition;


namespace ChainwideFoodOrderingSystem.ArchitectureTests.ClassDependencies;

public class CommandHandlerDependenciesTests
{
    private static readonly Architecture Architecture = CleanArchitectureSetup.ArchitectureForTesting;

    
    [Fact]
    public void CommandHandlers_Should_Not_Depend_On_Forbidden_Interfaces()
    {
        IArchRule rule = Types()
            .That().ImplementInterface(typeof(ICommandHandler<,>))
            .Should().NotDependOnAnyTypesThat()
            .ImplementInterface(typeof(IArchive<,>))
            .OrShould().ImplementInterface(typeof(IQueryHandler<,>))
            .OrShould().ImplementInterface(typeof(ICommandHandler<,>))
            .Because("CommandHandlers should not depend on IArchive, IQueryHandler, or ICommandHandler interfaces.");

        rule.Check(Architecture);
    }
}