//add a using directive to ArchUnitNET.Fluent.ArchRuleDefinition to easily define ArchRules

using ArchUnitNET.Domain;
using ArchUnitNET.Domain.Extensions;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using ChainwideFoodOrderingSystem.SeedWork.UseCase;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Query;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ChainwideFoodOrderingSystem.ArchitectureTests.ClassEnforcements;

/// <summary>
/// UseCase 層類別責任與繼承關係
/// </summary>
public class UseCaseLayerEnforcementTests
{
    private static readonly Architecture Architecture = CleanArchitectureSetup.ArchitectureForTesting;
    
    /// <summary>
    /// 測試 UseCase 層的介面命名是否以 UseCase 結尾，並實作 ICommandHandler 或 IQueryHandler
    /// </summary>
    [Fact]
    public void UseCase_Interfaces_Should_End_With_UseCase_And_Implement_Handlers()
    {
        IArchRule architectureRule = Interfaces()
            .That().ResideInNamespace(".*\\.InputPort", true)
            .And().HaveNameEndingWith("UseCase")
            .And().ImplementInterface(typeof(IUseCase<,>))
            .Should().ImplementInterface(typeof(ICommandHandler<,>))
            .OrShould().ImplementInterface(typeof(IQueryHandler<,>))
            .Because("InputPort 層中的 UseCase 介面應該以 UseCase 結尾並實作 ICommandHandler 或 IQueryHandler");

        architectureRule.Check(Architecture);
    }
    
    /// <summary>
    /// 測試 UseCase 層的 Repository 介面命名是否以 Repository 結尾，並實作 IRepository
    /// </summary>
    [Fact]
    public void UseCase_Repository_Interfaces_Should_End_With_Repository_And_Implement_IRepository()
    {
        IArchRule architectureRule = Interfaces()
            .That().ResideInNamespace(".*\\.OutputPort", true)
            .And().HaveNameEndingWith("Repository")
            .Should().ImplementInterface(typeof(IRepository<,>))
            .Because("OutputPort 層中的 Repository 介面應該以 Repository 結尾並實作 IRepository");

        architectureRule.Check(Architecture);
    }
}