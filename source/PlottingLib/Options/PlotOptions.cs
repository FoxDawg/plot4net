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
        public LineType LineType { get; } = LineType.ScatterAndLine;

        /// <summary>
        ///     The marker color to use.
        /// </summary>
        public Color MarkerColor { get; } = Color.Black;

        /// <summary>
        /// Color for the line plot.
        /// </summary>
        public Color LineColor { get; } = Color.Black;

        /// <summary>
        /// Width of the line.
        /// </summary>
        public double LineWidth { get; } = 1;

        /// <summary>
        ///     The marker size to use.
        /// </summary>
        public double MarkerSize { get; } = 5;
    }
}