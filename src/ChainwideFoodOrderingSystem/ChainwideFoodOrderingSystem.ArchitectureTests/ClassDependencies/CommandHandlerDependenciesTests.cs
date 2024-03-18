using ArchUnitNET.Domain;
using ArchUnitNET.Domain.Extensions;
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
    public void CommandHandlers_Should_Not_Depend_On_IArchive()
    {
        IArchRule rule = Types()
            .That().ImplementInterface(typeof(ICommandHandler<,>))
            .Should().NotDependOnAnyTypesThat().ImplementInterface(typeof(IArchive<,>))
            .Because("CommandHandlers should not depend on IArchive interface.");

        rule.Check(Architecture);
    }
    
    [Fact]
    public void CommandHandlers_Should_Not_Depend_On_IProjection()
    {
        IArchRule rule = Types()
            .That().ImplementInterface(typeof(ICommandHandler<,>))
            .Should().NotDependOnAnyTypesThat().ImplementInterface(typeof(IProjection<,>))
            .Because("CommandHandlers should not depend on IProjection interface.");

        rule.Check(Architecture);
    }
    
    [Fact]
    public void CommandHandlers_Should_Not_Depend_On_IQueryHandler()
    {
        IArchRule rule = Types()
            .That().ImplementInterface(typeof(ICommandHandler<,>))
            .Should().NotDependOnAnyTypesThat().ImplementInterface(typeof(IQueryHandler<,>))
            .Because("CommandHandlers should not depend on IQueryHandler interface.");

        rule.Check(Architecture);
    }
    
}