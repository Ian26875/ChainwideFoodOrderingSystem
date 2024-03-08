using ArchUnitNET.Domain;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ChainwideFoodOrderingSystem.ArchitectureTests.NamingConventions;

/// <summary>
/// 層命名約定測試
/// </summary>
public class LayerNamingConventionsTests
{
    private static readonly Architecture ProjectArchitecture = CleanArchitectureSetup.ArchitectureForTesting;

    /// <summary>
    /// 確認 Entity 層的類別位於以 Entity 結尾的命名空間中
    /// </summary>
    [Fact]
    public void Classes_In_EntityLayer_Should_Reside_In_Entity_Namespace()
    {
        foreach (var entityLayerAssembly in CleanArchitectureSetup.EntityLayerAssemblies)
        {
            Classes()
                .That().ResideInAssembly(entityLayerAssembly)
                .Should().ResideInNamespace(".*\\.Entity", true)
                .Because("Entity 層的類別應該位於以 Entity 結尾的命名空間中")
                .Check(ProjectArchitecture);
        }
    }

    /// <summary>
    /// 確認 UseCase 層的類別位於以 UseCase 結尾的命名空間中
    /// </summary>
    [Fact]
    public void Classes_In_UseCaseLayer_Should_Reside_In_UseCase_Namespace()
    {
        foreach (var useCaseLayerAssembly in CleanArchitectureSetup.UseCaseLayerAssemblies)
        {
            Classes()
                .That().ResideInAssembly(useCaseLayerAssembly)
                .Should().ResideInNamespace(".*\\.UseCase", true)
                .Because("UseCase 層的類別應該位於以 UseCase 結尾的命名空間中")
                .Check(ProjectArchitecture);
        }
    }
}
