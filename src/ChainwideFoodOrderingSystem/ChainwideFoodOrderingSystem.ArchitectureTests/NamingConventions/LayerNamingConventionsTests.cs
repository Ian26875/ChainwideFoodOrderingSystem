using ArchUnitNET.Domain;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ChainwideFoodOrderingSystem.ArchitectureTests.NamingConventions;

public class LayerNamingConventionsTests
{
    private static readonly Architecture ProjectArchitecture = CleanArchitectureConfiguration.ProjectArchitecture;


    [Fact]
    public void Entity_Layer_Classes_Should_Reside_In_Entity_Namespace()
    {
        foreach (var entityLayerAssembly in CleanArchitectureConfiguration.EntityLayers)
        {
            Classes()
                .That().ResideInAssembly(entityLayerAssembly)
                .Should().ResideInNamespace(".*\\.Entity", true)
                .Check(ProjectArchitecture);
        }
    }

    [Fact]
    public void UseCase_Layer_Classes_Should_Reside_In_UseCase_Namespace()
    {
        foreach (var useCaseLayerAssembly in CleanArchitectureConfiguration.UseCaseLayers)
        {
            Classes()
                .That().ResideInAssembly(useCaseLayerAssembly)
                .Should().ResideInNamespace(".*\\.UseCase", true)
                .Check(ProjectArchitecture);
        }
    }
}