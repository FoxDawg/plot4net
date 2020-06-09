using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using plot4net.Core.Contract;
using plot4net.Core.Options;

namespace plot4net.Core.Wpf.Plotter
{
    /// <summary>
    ///     A simple plotter for the figure axes.
    /// </summary>
    internal class AxisPlotter : ISimplePlot
    {
        private readonly AxisOptions options;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AxisPlotter" />
        /// </summary>
        /// <param name="options">The figure options to use.</param>
        public AxisPlotter(AxisOptions options)
        {
            this.options = options;
        }

        /// <summary>
        ///     Performs a simple plotting operation without any additional data.
        /// </summary>
        public void Plot(object uiParent)
        {
            if (uiParent is Canvas canvas)
            {
                this.AddHorizontalAxis(canvas);
                this.AddVerticalAxis(canvas);
            }
            else
            {
                throw new ArgumentException($"UiParent must be of type {typeof(Canvas)}.");
            }
        }

        private void AddHorizontalAxis(Canvas parentCanvas)
        {
            var canvasWidth = parentCanvas.ActualWidth;
            var canvasHeight = parentCanvas.ActualHeight;

            var relativeMarginToBorder = this.options.RelativeAxisMarginToBorder;

            var xAxis = new Line
            {
                Name = "xAxis",
                StrokeThickness = 1,
                X1 = 0,
                X2 = (1.0 - 2 * relativeMarginToBorder) * canvasWidth,
                Y1 = 0,
                Y2 = 0,
                Margin = new Thickness(0),
                Stroke = new SolidColorBrush(Colors.Black)
            };

            parentCanvas.Children.Add(xAxis);
            Canvas.SetLeft(xAxis, relativeMarginToBorder * canvasWidth);
            Canvas.SetBottom(xAxis, relativeMarginToBorder * canvasHeight);
        }

        private void AddVerticalAxis(Canvas parentCanvas)
        {
            var canvasWidth = parentCanvas.ActualWidth;
            var canvasHeight = parentCanvas.ActualHeight;

            var relativeMarginToBorder = this.options.RelativeAxisMarginToBorder;

            var yAxis = new Line
            {
                Name = "yAxis",
                StrokeThickness = 1,
                X1 = 0,
                X2 = 0,
                Y1 = 0,
                Y2 = (1.0 - 2 * relativeMarginToBorder) * canvasHeight,
                Margin = new Thickness(0),
                Stroke = new SolidColorBrush(Colors.Black)
            };

            parentCanvas.Children.Add(yAxis);
            Canvas.SetLeft(yAxis, relativeMarginToBorder * canvasWidth);
            Canvas.SetTop(yAxis, relativeMarginToBorder * canvasHeight);
        }
    }
}