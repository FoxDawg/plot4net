using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PlottingLib.Contract;
using PlottingLib.Helper;
using PlottingLib.Options;

namespace PlottingControls.Shared.Plotter
{
    /// <summary>
    ///     A simple plotter for the figure axis ticks.
    /// </summary>
    internal class AxisTickPlotter : ISimplePlot
    {
        private readonly AxisOptions options;
        private const double TickLength = 4;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AxisTickPlotter" />
        /// </summary>
        /// <param name="options">The figure options to use.</param>
        public AxisTickPlotter(AxisOptions options)
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
                this.AddHorizontalAxisTicks(canvas);
                this.AddVerticalAxisTicks(canvas);
            }
            else
            {
                throw new ArgumentException($"UiParent must be of type {typeof(Canvas)}.");
            }
        }

        private void AddHorizontalAxisTicks(Canvas parentCanvas)
        {
            var canvasWidth = parentCanvas.ActualWidth;
            var canvasHeight = parentCanvas.ActualHeight;

            var relativeMarginToBorder = this.options.RelativeAxisMarginToBorder;


            var xTicks = this.options.XTicks;

            foreach (var tick in xTicks)
            {
                var tickElement = new Line
                {
                    StrokeThickness = 1,
                    X1 = 0,
                    X2 = 0,
                    Y1 = 0,
                    Y2 = TickLength,
                    Margin = new Thickness(0),
                    Stroke = new SolidColorBrush(Colors.Black)
                };

                var tickLabel = new Label
                {
                    Content = tick.ToString("g2"),
                    Width = 40,
                    Height = 25,
                    FontSize = this.options.TickLabelFontSize,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(0)
                };

                parentCanvas.Children.Add(tickElement);
                parentCanvas.Children.Add(tickLabel);

                var px = Converter.FromDataToUi(tick, this.options.XRange, canvasWidth, relativeMarginToBorder);

                Canvas.SetLeft(tickElement, px);
                Canvas.SetBottom(tickElement, relativeMarginToBorder * canvasHeight - TickLength);

                Canvas.SetLeft(tickLabel, px - tickLabel.Width / 2);
                Canvas.SetBottom(tickLabel, relativeMarginToBorder * canvasHeight - tickLabel.Height);
            }
        }

        private void AddVerticalAxisTicks(Canvas parentCanvas)
        {
            var canvasWidth = parentCanvas.ActualWidth;
            var canvasHeight = parentCanvas.ActualHeight;

            var relativeMarginToBorder = this.options.RelativeAxisMarginToBorder;

            var yTicks = this.options.YTicks;

            foreach (var tick in yTicks)
            {
                var tickElement = new Line
                {
                    StrokeThickness = 1,
                    X1 = 0,
                    X2 = TickLength,
                    Y1 = 0,
                    Y2 = 0,
                    Margin = new Thickness(0),
                    Stroke = new SolidColorBrush(Colors.Black)
                };

                var tickLabel = new Label
                {
                    Content = tick.ToString("g2"),
                    Width = 40,
                    Height = 25,
                    FontSize = this.options.TickLabelFontSize,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0)
                };

                parentCanvas.Children.Add(tickElement);
                parentCanvas.Children.Add(tickLabel);

                var py = Converter.FromDataToUi(tick, this.options.YRange, canvasHeight, relativeMarginToBorder);
                Canvas.SetLeft(tickElement, relativeMarginToBorder * canvasWidth - TickLength);
                Canvas.SetBottom(tickElement, py);

                Canvas.SetLeft(tickLabel, relativeMarginToBorder * canvasWidth - TickLength - tickLabel.Width);
                Canvas.SetBottom(tickLabel, py - tickLabel.Height / 2);
            }
        }
    }
}