using FluentAssertions;
using PlottingLib.Helper;
using Xunit;

namespace PlottingLib.UnitTests
{
    [Trait("Category", "Unit")]
    public class ConverterTests
    {
        [Theory]
        [InlineData(0, new double[] {0, 10}, 100, 0, 0)]
        [InlineData(0, new double[] {0, 10}, 100, 0.1, 10)]
        [InlineData(0, new double[] {0, 10}, 100, 0.2, 20)]
        [InlineData(10, new double[] {0, 10}, 100, 0, 100)]
        [InlineData(10, new double[] {0, 10}, 100, 0.1, 90)]
        [InlineData(10, new double[] {0, 20}, 100, 0.1, 50)]
        [InlineData(10, new double[] {0, 20}, 100, 0.2, 50)]
        [InlineData(1, new double[] {1, 4}, 100, 0.1, 10)]
        public void ConvertDataValue(double value, double[] allValues, double actualWidth, double relativeMargin, double expectedValue)
        {
            //Act
            var uiValue = Converter.FromDataToUi(value, allValues, actualWidth, relativeMargin);

            uiValue.Should().BeApproximately(expectedValue, 0.1);
        }
    }
}