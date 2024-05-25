using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace ChainwideFoodOrderingSystem.Order.UseCaseTests.TestCustomizations;

public class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute() 
        : base(() => new Fixture().Customize(new AutoMoqCustomization()))
    {
    }
}
