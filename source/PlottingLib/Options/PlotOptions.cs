using System.Drawing;
using PlottingLib.Enum;

namespace PlottingLib.Options
{
    /// <summary>
    ///     Data object to hold plot options.
    /// </summary>
    public class PlotOptions
    {
        /// <summary>
        ///     The line type used for plotting.
        /// </summary>
        public LineType LineType { get; } = LineType.Scatter;

        /// <summary>
        ///     The range mode for determining axis ranges.
        /// </summary>
        public RangeMode RangeMode { get; } = RangeMode.Auto;

        /// <summary>
        ///     The marker color to use.
        /// </summary>
        public Color MarkerColor { get; } = Color.Black;

        /// <summary>
        ///     The marker size to use.
        /// </summary>
        public double MarkerSize { get; } = 5;
    }
}