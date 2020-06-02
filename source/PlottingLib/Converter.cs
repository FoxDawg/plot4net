using System.Linq;

namespace PlottingLib
{
    /// <summary>
    ///     Helper class to perform various conversions.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        ///     Converts from data to UI values.
        /// </summary>
        /// <param name="value">The value to converts.</param>
        /// <param name="allValues">The range of values to base the conversion on.</param>
        /// <param name="actualWidth">The width of the UI element.</param>
        /// <param name="relativeMargin">The relative margin of the plotting area to the actual width.</param>
        /// <returns></returns>
        public static double FromDataToUi(double value, double[] allValues, double actualWidth, double relativeMargin)
        {
            var widthOfDrawingArea = actualWidth * (1 - 2 * relativeMargin);
            var offset = actualWidth * relativeMargin;

            var minimumValue = allValues.Min();
            var maximumValue = allValues.Max();
            var dataRange = maximumValue - minimumValue;


            var convertedValue = (value - minimumValue) / dataRange * widthOfDrawingArea + offset;

            return convertedValue;
        }
    }
}