using System.Drawing;

using plot4net.Core.Enum;

namespace plot4net.Core.Options
{
    /// <summary>
    /// Data object to hold plot options.
    /// </summary>
    public class PlotOptions
    {
        /// <summary>
        /// The line type used for plotting.
        /// </summary>
        public LineType LineType { get; set; } = LineType.ScatterAndLine;

        /// <summary>
        /// The marker color to use.
        /// </summary>
        public Color MarkerColor { get; set; }

        /// <summary>
        /// Color for the line plot.
        /// </summary>
        public Color LineColor { get; set; }

        /// <summary>
        /// Width of the line.
        /// </summary>
        public double LineWidth { get; set; } = 1;

        /// <summary>
        /// The marker size to use.
        /// </summary>
        public double MarkerSize { get; set; } = 5;
    }
}