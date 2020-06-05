﻿using System.Drawing;
using PlottingLib.Enum;

namespace PlottingLib.Options
{
    /// <summary>
    ///     Options for figure axes.
    /// </summary>
    public class AxisOptions
    {
        /// <summary>
        ///     The relative margin of the plot to the border on both sides.
        /// </summary>
        public double RelativeAxisMarginToBorder { get; set; } = 0.12;

        /// <summary>
        ///     The range mode for determining axis ranges.
        /// </summary>
        public RangeMode RangeMode { get; } = RangeMode.Auto;

        /// <summary>
        ///     Range for the horizontal axis.
        /// </summary>
        public double[] XRange { get; set; } = {0, 1};

        /// <summary>
        /// Tick positions for the horizontal axis.
        /// </summary>
        public double[] XTicks { get; set; }

        /// <summary>
        ///     Range for the vertical axis.
        /// </summary>
        public double[] YRange { get; set; } = {0, 1};

        /// <summary>
        /// Tick positions for the vertical axis.
        /// </summary>
        public double[] YTicks { get; set; }

        /// <summary>
        ///     Label for the horizontal axis.
        /// </summary>
        public string XLabel { get; set; } = "x";

        /// <summary>
        ///     Label for the vertical axis.
        /// </summary>
        public string YLabel { get; set; } = "y";

        /// <summary>
        ///     Number of ticks to display.
        /// </summary>
        public int NumberOfTicks { get; set; } = 5;

        /// <summary>
        ///     Font size for tick labels.
        /// </summary>
        public int TickLabelFontSize { get; set; } = 12;

        /// <summary>
        ///     Font size for axis labels.
        /// </summary>
        public int AxisLabelFontSize { get; set; } = 12;

        /// <summary>
        ///     LineWidth for grid lines.
        /// </summary>
        public double GridLineWidth { get; set; } = 0.2;

        /// <summary>
        ///     Color for grid lines.
        /// </summary>
        public Color GridLineColor { get; set; } = Color.DimGray;

        /// <summary>
        /// The grid mode.
        /// </summary>
        public GridMode GridMode { get; set; } = GridMode.HorizontalAndVertical;
    }
}