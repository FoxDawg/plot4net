using System.Collections.Generic;
using System.Drawing;

using plot4net.Core.Enum;

namespace plot4net.Core.Options
{
    /// <summary>
    /// Data object to hold plot options.
    /// </summary>
    public class PlotOptions
    {
        private static int lineColorIndex;

        private static readonly IList<Color> LineColors = new List<Color>
        {
            Color.Black,
            Color.DodgerBlue,
            Color.DarkOrange,
            Color.DarkRed,
            Color.DarkGreen,
            Color.Gold
        };

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

        /// <summary>
        /// Creates a new instance of <see cref="PlotOptions" />
        /// </summary>
        public PlotOptions()
        {
            this.LineColor = LineColors[lineColorIndex];
            this.MarkerColor = LineColors[lineColorIndex];
            lineColorIndex = ++lineColorIndex % LineColors.Count;
        }
    }
}