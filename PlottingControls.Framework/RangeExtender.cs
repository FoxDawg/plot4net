using System.Collections.Generic;
using System.Linq;

namespace PlottingControls.Framework
{
    /// <summary>
    ///     Performs operations to calculate axis ranges.
    /// </summary>
    public class RangeExtender
    {
        /// <summary>
        ///     Performs automatic range extension for the given data.
        /// </summary>
        /// <param name="data">The data to perform calculations on.</param>
        /// <returns>The extended range data.</returns>
        public double[] ExtendRange(double[] data)
        {
            var dataRange = data.Max() - data.Min();
            var extendedData = new List<double>();
            extendedData.Add(data.Min() - 0.1 * dataRange);
            extendedData.AddRange(data);
            extendedData.Add(data.Max() + 0.1 * dataRange);

            return extendedData.ToArray();
        }
    }
}