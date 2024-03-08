//add a using directive to ArchUnitNET.Fluent.ArchRuleDefinition to easily define ArchRules
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using ChainwideFoodOrderingSystem.SeedWork.UseCase;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Command;
using ChainwideFoodOrderingSystem.SeedWork.UseCase.Cqrs.Query;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ChainwideFoodOrderingSystem.ArchitectureTests.NamingConventions;

/// <summary>
/// UseCase 層命名慣例與介面
/// </summary>
public class UseCaseLayerConventionsTests
{
    private static readonly Architecture ProjectArchitecture = CleanArchitectureSetup.ArchitectureForTesting;
    
    /// <summary>
    /// 測試 UseCase 層的介面命名字尾是否為 UseCase
    /// </summary>
    [Fact]
    public void UseCase_InterfaceOfUseCases_Should_End_With_UseCase()
    {
        foreach (var useCaseLayerAssembly in CleanArchitectureSetup.UseCaseLayerAssemblies)
        {
            IArchRule architectureRule = Interfaces()
                .That().ResideInAssembly(useCaseLayerAssembly)
                .And().AreAssignableTo(typeof(IUseCase<,>))
                .Should().HaveNameEndingWith("UseCase")
                .Because("在UseCase層InputPort資料夾，宣告實作ICommandHandler或IQueryHandler介面，必須以'UseCase'作為命名字尾。")
                .AndShould().HaveNameStartingWith("I")
                .Because("在C#語言中介面命名必須是I為命名開頭。");

            architectureRule.Check(ProjectArchitecture);
        }
    }
    
    /// <summary>
    /// 測試 UseCase 層的 Repository 介面命名字尾是否為 Repository
    /// </summary>
    [Fact]
    public void UseCase_InterfaceOfRepository_Should_End_With_Repository()
    {
        foreach (var useCaseLayerAssembly in CleanArchitectureSetup.UseCaseLayerAssemblies)
        {
            IArchRule rule = Interfaces()
                .That().ResideInAssembly(useCaseLayerAssembly)
                .And().ResideInNamespace(".*\\.OutputPort$", true)
                .And().AreAssignableTo(typeof(IRepository<,>))
                .Should().HaveNameEndingWith("Repository")
                .Because("在 UseCase 層 InputPort 資料夾，宣告繼承 IRepository 的介面必須以 'Repository' 作為命名字尾。")
                .AndShould().HaveNameStartingWith("I")
                .Because("在 C# 語言中介面命名必須是 I 為命名開頭。");

            rule.Check(ProjectArchitecture);
        }
    }
    
    /// <summary>
    /// 測試 UseCase 層的類別命名字尾是否為 UseCase
    /// </summary>
    [Fact]
    public void UseCase_Classes_Should_Naming_End_With_UseCase()
    {
        foreach (var useCaseLayerAssembly in CleanArchitectureSetup.UseCaseLayerAssemblies)
        {
            IArchRule rule = Classes()
                .That().ResideInAssembly(useCaseLayerAssembly)
                .And().ResideInNamespace(".*\\.UseCase$", true)
                .Should().HaveNameEndingWith("UseCase")
                .Because("在UseCase層的根目錄中實作類別，必須以'UseCase'作為命名字尾。");

            rule.Check(ProjectArchitecture);
        }
    }
}
