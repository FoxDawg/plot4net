using System;
using System.Linq;
using PlottingLib.Enum;
using PlottingLib.Options;

namespace PlottingLib.Helper
{
    /// <summary>
    ///     Performs operations to calculate axis ranges.
    /// </summary>
    public static class RangeExtender
    {
        /// <summary>
        ///     Performs automatic range extension for the given data.
        /// </summary>
        /// <param name="data">The data to perform calculations on.</param>
        /// <param name="axisOptions">The axis options to use.</param>
        /// <returns>The extended range data.</returns>
        public static void ExtendHorizontalRange(double[] data, AxisOptions axisOptions)
        {
            if (axisOptions.RangeMode == RangeMode.Auto)
            {
                var dataRange = data.Max() - data.Min();
                var range1 = data.Min() - 0.1 * dataRange;
                var range2 = data.Max() + 0.1 * dataRange;

                axisOptions.XRange = new[] { Math.Min(range1, range2), Math.Max(range1, range2) };
            }
        }

        /// <summary>
        ///     Performs automatic range extension for the given data.
        /// </summary>
        /// <param name="data">The data to perform calculations on.</param>
        /// <param name="axisOptions">The axis options to use.</param>
        /// <returns>The extended range data.</returns>
        public static void ExtendVerticalRange(double[] data, AxisOptions axisOptions)
        {
            if (axisOptions.RangeMode == RangeMode.Auto)
            {
                var dataRange = data.Max() - data.Min();
                var range1 = data.Min() - 0.1 * dataRange;
                var range2 = data.Max() + 0.1 * dataRange;

                axisOptions.YRange = new[] { Math.Min(range1, range2), Math.Max(range1, range2) };
            }
        }
    }
}