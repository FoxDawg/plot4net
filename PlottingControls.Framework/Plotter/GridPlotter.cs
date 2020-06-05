using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PlottingLib;
using PlottingLib.Contract;
using PlottingLib.Helper;
using PlottingLib.Options;

namespace PlottingControls.Framework.Plotter
{
    /// <summary>
    ///     A simple plotter for the figure axes.
    /// </summary>
    internal class GridPlotter : ISimplePlot
    {
        private readonly AxisOptions options;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AxisPlotter" />
        /// </summary>
        /// <param name="options">The figure options to use.</param>
        public GridPlotter(AxisOptions options)
        {
            this.options = options;
        }

        public void Plot(object uiParent)
        {
            if (uiParent is Canvas canvas)
            {
                var xTicks = FigureHelper.CalculateTicks(this.options.XRange, this.options.NumberOfTicks);
                var yTicks = FigureHelper.CalculateTicks(this.options.YRange, this.options.NumberOfTicks);
                switch (this.options.GridMode)
                {
                    case GridMode.None:
                        return;
                    case GridMode.HorizontalAndVertical:
                        this.AddHorizontalGridLines(canvas, yTicks);
                        this.AddVerticalGridLines(canvas, xTicks);
                        break;
                    case GridMode.Horizontal:
                        this.AddHorizontalGridLines(canvas, yTicks);
                        break;
                    case GridMode.Vertical:
                        this.AddVerticalGridLines(canvas, xTicks);
                        break;
                }
            }
            else
            {
                throw new ArgumentException($"UiParent must be of type {typeof(Canvas)}.");
            }
        }


        private void AddHorizontalGridLines(Canvas parentCanvas, double[] ticks)
        {
            var canvasWidth = parentCanvas.ActualWidth;
            var canvasHeight = parentCanvas.ActualHeight;

            var relativeMarginToBorder = this.options.RelativeAxisMarginToBorder;

            for (var i = 1; i < ticks.Length; i++)
            {
                var gridLine = new Line
                {
                    StrokeThickness = this.options.GridLineWidth,
                    X1 = 0,
                    X2 = (1.0 - 2 * relativeMarginToBorder) * canvasWidth,
                    Y1 = 0,
                    Y2 = 0,
                    Margin = new Thickness(0),
                    Stroke = new SolidColorBrush(ColorConverter.ToWindowsMedia(this.options.GridLineColor))
                };

                var py = Converter.FromDataToUi(ticks[i], this.options.YRange, canvasHeight, relativeMarginToBorder);

                parentCanvas.Children.Add(gridLine);
                Canvas.SetLeft(gridLine, relativeMarginToBorder * canvasWidth);
                Canvas.SetBottom(gridLine, py);
            }
        }

        private void AddVerticalGridLines(Canvas parentCanvas, double[] ticks)
        {
            var canvasWidth = parentCanvas.ActualWidth;
            var canvasHeight = parentCanvas.ActualHeight;

            var relativeMarginToBorder = this.options.RelativeAxisMarginToBorder;

            for (var i = 1; i < ticks.Length; i++)
            {
                var gridLine = new Line
                {
                    StrokeThickness = this.options.GridLineWidth,
                    X1 = 0,
                    X2 = 0,
                    Y1 = 0,
                    Y2 = (1.0 - 2 * relativeMarginToBorder) * canvasHeight,
                    Margin = new Thickness(0),
                    Stroke = new SolidColorBrush(ColorConverter.ToWindowsMedia(this.options.GridLineColor))
                };

                var px = Converter.FromDataToUi(ticks[i], this.options.XRange, canvasWidth, relativeMarginToBorder);
                parentCanvas.Children.Add(gridLine);
                Canvas.SetLeft(gridLine, px);
                Canvas.SetTop(gridLine, relativeMarginToBorder * canvasHeight);
            }
        }
    }
}