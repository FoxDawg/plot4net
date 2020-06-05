using System;
using System.Collections.Generic;
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

                axisOptions.XRange = new[] {Math.Min(range1, range2), Math.Max(range1, range2)};
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

                axisOptions.YRange = new[] {Math.Min(range1, range2), Math.Max(range1, range2)};
            }
        }

        /// <summary>
        ///     Sets the axis ticks for the horizontal axis.
        /// </summary>
        /// <param name="axisOptions">The axis options to write to.</param>
        public static void SetHorizontalAxisTicks(AxisOptions axisOptions)
        {
            axisOptions.XTicks = CalculateTicks(axisOptions.XRange[0], axisOptions.XRange[1], axisOptions.NumberOfTicks);
        }

        /// <summary>
        ///     Sets the axis ticks for the vertical axis.
        /// </summary>
        /// <param name="axisOptions">The axis options to write to.</param>
        public static void SetVerticalAxisTicks(AxisOptions axisOptions)
        {
            axisOptions.YTicks = CalculateTicks(axisOptions.YRange[0], axisOptions.YRange[1], axisOptions.NumberOfTicks);
        }

        private static double[] CalculateTicks(double minValue, double maxValue, int numberOfTicks)
        {
            var range = maxValue - minValue;

            var tickDistance = Mathematic.CalculateTickStepSize(range, numberOfTicks);

            var ticks = new List<double>();
            for (var i = 0; i < numberOfTicks; i++)
            {
                var newTick = minValue + i * tickDistance;
                if (newTick <= maxValue)
                {
                    ticks.Add(newTick);
                }
            }

            return ticks.ToArray();
        }
    }
}