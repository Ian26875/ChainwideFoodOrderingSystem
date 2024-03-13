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
///     UseCase 層命名慣例與介面
/// </summary>
public class UseCaseLayerConventionsTests
{
    private static readonly Architecture ProjectArchitecture = CleanArchitectureSetup.ArchitectureForTesting;

    /// <summary>
    ///     測試 UseCase 層的介面命名字尾是否為 UseCase
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
    ///     測試 UseCase 層的 Repository 介面命名字尾是否為 Repository
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
                .Because("在 UseCase 層 OutputPort 資料夾，宣告繼承 IRepository 的介面必須以 'Repository' 作為命名字尾。")
                .AndShould().HaveNameStartingWith("I")
                .Because("在 C# 語言中介面命名必須是 I 為命名開頭。");

            rule.Check(ProjectArchitecture);
        }
    }


    /// <summary>
    ///     測試 UseCase 層的 Repository 介面命名字尾是否為 Repository
    /// </summary>
    [Fact]
    public void UseCase_InterfaceOfProjection_Should_End_With_Projection()
    {
        foreach (var useCaseLayerAssembly in CleanArchitectureSetup.UseCaseLayerAssemblies)
        {
            IArchRule rule = Interfaces()
                .That().ResideInAssembly(useCaseLayerAssembly)
                .And().ResideInNamespace(".*\\.OutputPort$", true)
                .And().AreAssignableTo(typeof(IProjection<,>))
                .Should().HaveNameEndingWith("Projection")
                .Because("在 UseCase 層 OutputPort 資料夾，宣告繼承 IProjection 的介面必須以 'Projection' 作為命名字尾。")
                .AndShould().HaveNameStartingWith("I")
                .Because("在 C# 語言中介面命名必須是 I 為命名開頭。");

            rule.Check(ProjectArchitecture);
        }
    }

    /// <summary>
    ///     測試 UseCase 層的 Repository 介面命名字尾是否為 Repository
    /// </summary>
    [Fact]
    public void UseCase_InterfaceOfInquiry_Should_End_With_Inquiry()
    {
        foreach (var useCaseLayerAssembly in CleanArchitectureSetup.UseCaseLayerAssemblies)
        {
            IArchRule rule = Interfaces()
                .That().ResideInAssembly(useCaseLayerAssembly)
                .And().ResideInNamespace(".*\\.OutputPort$", true)
                .And().AreAssignableTo(typeof(IInquiry<,>))
                .Should().HaveNameEndingWith("Inquiry")
                .Because("在 UseCase 層 Output 資料夾，宣告繼承 IInquiry 的介面必須以 'Inquiry' 作為命名字尾。")
                .AndShould().HaveNameStartingWith("I")
                .Because("在 C# 語言中介面命名必須是 I 為命名開頭。");

            rule.Check(ProjectArchitecture);
        }
    }

    /// <summary>
    ///     測試 UseCase 層的 Repository 介面命名字尾是否為 Repository
    /// </summary>
    [Fact]
    public void UseCase_InterfaceOfArchive_Should_End_With_Archive()
    {
        foreach (var useCaseLayerAssembly in CleanArchitectureSetup.UseCaseLayerAssemblies)
        {
            IArchRule rule = Interfaces()
                .That().ResideInAssembly(useCaseLayerAssembly)
                .And().ResideInNamespace(".*\\.OutputPort$", true)
                .And().AreAssignableTo(typeof(IArchive<,>))
                .Should().HaveNameEndingWith("Archive")
                .Because("在 UseCase 層 Output 資料夾，宣告繼承 IArchive 的介面必須以 'Archive' 作為命名字尾。")
                .AndShould().HaveNameStartingWith("I")
                .Because("在 C# 語言中介面命名必須是 I 為命名開頭。");

            rule.Check(ProjectArchitecture);
        }
    }


    /// <summary>
    ///     測試 UseCase 層的類別命名字尾是否為 UseCase
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