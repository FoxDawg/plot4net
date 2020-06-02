using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PlottingLib.Contract;
using PlottingLib.Options;

namespace PlottingControls.Framework.Plotter
{
    /// <summary>
    ///     A simple plotter for the figure axes.
    /// </summary>
    public class AxisPlotter : ISimplePlot
    {
        private readonly Canvas canvas;
        private readonly FigureOptions options;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AxisPlotter" />
        /// </summary>
        /// <param name="canvas">The canvas to use for plotting.</param>
        /// <param name="options">The figure options to use.</param>
        public AxisPlotter(Canvas canvas, FigureOptions options)
        {
            this.canvas = canvas;
            this.options = options;
        }

        /// <summary>
        ///     Performs a simple plotting operation without any additional data.
        /// </summary>
        public void Plot()
        {
            this.AddHorizontalAxis(this.canvas);
            this.AddVerticalAxis(this.canvas);
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
            Canvas.SetTop(xAxis, (1.0 - relativeMarginToBorder) * canvasHeight);
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
                Y2 = (1.0 - 2 * relativeMarginToBorder) * canvasWidth,
                Margin = new Thickness(0),
                Stroke = new SolidColorBrush(Colors.Black)
            };

            parentCanvas.Children.Add(yAxis);
            Canvas.SetLeft(yAxis, relativeMarginToBorder * canvasWidth);
            Canvas.SetTop(yAxis, relativeMarginToBorder * canvasHeight);
        }
    }
}