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
    internal class ScatterPlotter : IDataPlot
    {
        private readonly AxisOptions axisOptions;
        private readonly PlotOptions plotOptions;

        /// <summary>
        /// Initializes a new instance of <see cref="ScatterPlotter" />
        /// </summary>
        /// <param name="axisOptions">The figure options to use.</param>
        /// <param name="plotOptions">The plot options to use.</param>
        public ScatterPlotter(AxisOptions axisOptions, PlotOptions plotOptions)
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
                var canvasWidth = canvas.ActualWidth;
                var canvasHeight = canvas.ActualHeight;

                var relativeMarginToBorder = this.axisOptions.RelativeAxisMarginToBorder;
                for (var i = 0; i < xData.Length; i++)
                {
                    var point = new Ellipse
                    {
                        Height = this.plotOptions.MarkerSize,
                        Width = this.plotOptions.MarkerSize,
                        Fill = new SolidColorBrush(ColorConverter.ToWindowsMedia(this.plotOptions.MarkerColor)),
                        Margin = new Thickness(0),
                        StrokeThickness = 0
                    };

                    var px = Converter.FromDataToUi(xData[i], this.axisOptions.XRange, canvasWidth, relativeMarginToBorder);
                    var py = Converter.FromDataToUi(yData[i], this.axisOptions.YRange, canvasHeight, relativeMarginToBorder);

                    Canvas.SetLeft(point, px);
                    Canvas.SetBottom(point, py);
                    canvas.Children.Add(point);
                }
            }
            else
            {
                throw new ArgumentException($"UiParent must be of type {typeof(Canvas)}.");
            }
        }
    }
}