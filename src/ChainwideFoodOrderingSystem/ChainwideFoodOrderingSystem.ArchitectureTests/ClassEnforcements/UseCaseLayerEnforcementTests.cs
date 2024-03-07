//add a using directive to ArchUnitNET.Fluent.ArchRuleDefinition to easily define ArchRules

using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using ChainwideFoodOrderingSystem.SeedWork.UseCase;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ChainwideFoodOrderingSystem.ArchitectureTests.ClassEnforcements;

/// <summary>
/// UseCase 層命名慣例與介面
/// </summary>
public class UseCaseTests
{
    private static readonly Architecture Architecture = ArchitectureTestSetup.Architecture;
    
    /// <summary>
    /// 測試 UseCase 層的介面命名字尾是否為 UseCase
    /// </summary>
    [Fact]
    public void UseCase_InterfaceOfUseCases_Should_End_With_UseCase()
    {
        IArchRule rule = Interfaces()
            .That().ResideInNamespace(".*\\.UseCase",true)
            .And().AreAssignableTo(typeof(IUseCase<,>))
            .Should().HaveNameEndingWith("UseCase")
            .AndShould().HaveNameStartingWith("I");

        rule.Check(Architecture);
    }
    
    /// <summary>
    /// 測試 UseCase 層的 Repository 介面命名字尾是否為 Repository
    /// </summary>
    [Fact]
    public void UseCase_InterfaceOfRepository_Should_End_With_Repository()
    {
        IArchRule rule = Interfaces()
            .That().ResideInNamespace(".*\\.UseCase",true)
            .And().AreAssignableTo(typeof(IRepository<,>))
            .Should().HaveNameEndingWith("Repository")
            .AndShould().HaveNameStartingWith("I");

        rule.Check(Architecture);
    }
    
    /// <summary>
    /// 測試 UseCase 層的類別命名字尾是否為 UseCase
    /// </summary>
    [Fact]
    public void UseCase_Classes_Should_Naming_End_With_UseCase()
    {
        IArchRule rule = Classes()
            .That().ResideInNamespace(".*\\.UseCase$",true)
            .Should().HaveNameEndingWith("UseCase");

        rule.Check(Architecture);
    }
}
