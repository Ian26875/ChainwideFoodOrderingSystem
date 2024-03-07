//add a using directive to ArchUnitNET.Fluent.ArchRuleDefinition to easily define ArchRules
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using ChainwideFoodOrderingSystem.SeedWork.UseCase;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ChainwideFoodOrderingSystem.ArchitectureTests.NamingConventions;

/// <summary>
/// UseCase 層命名慣例與介面
/// </summary>
public class UseCaseLayerConventionsTests
{
    private static readonly Architecture Architecture = ArchitectureTestSetup.Architecture;
    
    /// <summary>
    /// 測試 UseCase 層的介面命名字尾是否為 UseCase
    /// </summary>
    [Fact]
    public void UseCase_InterfaceOfUseCases_Should_End_With_UseCase()
    {
        IArchRule rule = Interfaces()
            .That().ResideInNamespace(@".*\.UseCase.InputPort.*\",true)
            .And().AreAssignableTo(typeof(IUseCase<,>))
            .Should().HaveNameEndingWith("UseCase")
            .Because("在UseCase層InputPort資料夾，宣告繼承IUseCase的介面必須以'UseCase'作為命名字尾。")
            .AndShould().HaveNameStartingWith("I")
            .Because("在C#語言中介面命名必須是I為命名開頭。");

        rule.Check(Architecture);
    }
    
    /// <summary>
    /// 測試 UseCase 層的 Repository 介面命名字尾是否為 Repository
    /// </summary>
    [Fact]
    public void UseCase_InterfaceOfRepository_Should_End_With_Repository()
    {
        IArchRule rule = Interfaces()
            .That().ResideInNamespace(".*\\.UseCase.OutputPort$",true)
            .And().AreAssignableTo(typeof(IRepository<,>))
            .Should().HaveNameEndingWith("Repository")
            .Because("在UseCase層OutputPort資料夾，宣告繼承IRepository的介面必須以'Repository'作為命名字尾。")
            .AndShould().HaveNameStartingWith("I")
            .Because("在C#語言中介面命名必須是I為命名開頭。");

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
            .Should().HaveNameEndingWith("UseCase")
            .Because("在UseCase層的根目錄中實作類別，必須以'UseCase'作為命名字尾。");

        rule.Check(Architecture);
    }
}
