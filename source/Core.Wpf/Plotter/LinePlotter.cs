using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using plot4net.Core.Contract;
using plot4net.Core.Helper;
using plot4net.Core.Options;

namespace plot4net.Core.Wpf.Plotter
{
    /// <summary>
    /// A plotter for data.
    /// </summary>
    internal class LinePlotter : IDataPlot
    {
        private readonly AxisOptions axisOptions;
        private readonly PlotOptions plotOptions;

        /// <summary>
        /// Initializes a new instance of <see cref="LinePlotter" />
        /// </summary>
        /// <param name="axisOptions">The figure options to use.</param>
        /// <param name="plotOptions">The plot options to use.</param>
        public LinePlotter(AxisOptions axisOptions, PlotOptions plotOptions)
        {
            this.axisOptions = axisOptions;
            this.plotOptions = plotOptions;
        }

        /// <summary>
        /// Plots two-dimensional data.
        /// </summary>
        /// <param name="uiParent">The uiParent to plot upon.</param>
        /// <param name="xData">xData to be plotted.</param>
        /// <param name="yData">yData to be plotted.</param>
        public void Plot(object uiParent, double[] xData, double[] yData)
        {
            if (uiParent is Canvas canvas)
            {
                if (!Mathematic.IsMonotonicIncreasing(xData) && !Mathematic.IsMonotonicDecreasing(xData))
                {
                    throw new InvalidOperationException("Data must monotonically increasing or decreasing.");
                }

                var canvasWidth = canvas.ActualWidth;
                var canvasHeight = canvas.ActualHeight;

                var relativeMarginToBorder = this.axisOptions.RelativeAxisMarginToBorder;
                for (var i = 0; i < xData.Length - 1; i++)
                {
                    var x1 = Converter.FromDataToUi(xData[i], this.axisOptions.XRange, canvasWidth, relativeMarginToBorder);
                    var x2 = Converter.FromDataToUi(xData[i + 1], this.axisOptions.XRange, canvasWidth, relativeMarginToBorder);
                    var y1 = Converter.FromDataToUi(yData[i], this.axisOptions.YRange, canvasHeight, relativeMarginToBorder);
                    var y2 = Converter.FromDataToUi(yData[i + 1], this.axisOptions.YRange, canvasHeight, relativeMarginToBorder);

                    var dX = x2 - x1;
                    var dY = y2 - y1;

                    var line = new Line
                    {
                        X1 = dX,
                        X2 = 0,
                        Y1 = 0,
                        Y2 = dY,
                        Stroke = new SolidColorBrush(ColorConverter.ToWindowsMedia(this.plotOptions.LineColor)),
                        Margin = new Thickness(0),
                        StrokeThickness = this.plotOptions.LineWidth
                    };

                    Canvas.SetLeft(line, x1 + 0.5 * this.plotOptions.MarkerSize);
                    Canvas.SetBottom(line, Math.Min(y2, y1) + 0.5 * this.plotOptions.MarkerSize);
                    canvas.Children.Add(line);
                }
            }
            else
            {
                throw new ArgumentException($"UiParent must be of type {typeof(Canvas)}.");
            }
        }
    }
}