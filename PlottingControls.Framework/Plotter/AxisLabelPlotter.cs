using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PlottingLib.Contract;
using PlottingLib.Options;

namespace PlottingControls.Framework.Plotter
{
    /// <summary>
    ///     Specific plotter for the title bar.
    /// </summary>
    internal class AxisLabelPlotter : ISimplePlot
    {
        private readonly AxisOptions options;

        /// <summary>
        ///     Creates a new instance of the <see cref="TitlePlotter" />
        /// </summary>
        /// <param name="options">The figure options to use.</param>
        public AxisLabelPlotter(AxisOptions options)
        {
            this.options = options;
        }


        /// <summary>
        ///     Performs a simple plotting operation without any additional data.
        /// </summary>
        /// <param name="uiParent">The ui parent to plot upon.</param>
        public void Plot(object uiParent)
        {
            if (uiParent is Canvas canvas)
            {
                this.PlotHorizontalLabel(canvas);
                this.PlotVerticalLabel(canvas);
            }
            else
            {
                throw new ArgumentException($"UiParent must be of type {typeof(Canvas)}.");
            }
        }

        private void PlotHorizontalLabel(Canvas canvas)
        {
            if (string.IsNullOrEmpty(this.options.XLabel))
            {
                return;
            }

            var text = new Label
            {
                Content = this.options.XLabel,
                Margin = new Thickness(0),
                Width = canvas.ActualWidth,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Top,
            };

            Canvas.SetBottom(text, 0.25 * this.options.RelativeAxisMarginToBorder * canvas.ActualHeight);
            Canvas.SetLeft(text, 0);

            canvas.Children.Add(text);
        }

        private void PlotVerticalLabel(Canvas canvas)
        {
            if (string.IsNullOrEmpty(this.options.YLabel))
            {
                return;
            }

            var text = new Label
            {
                Content = this.options.YLabel,
                RenderTransform = new RotateTransform(-90,0,25),
                Margin = new Thickness(0),
                Width = canvas.ActualHeight,
                Height = 25,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Bottom,
            };

            Canvas.SetBottom(text, 0 );
            Canvas.SetLeft(text, 0 + this.options.RelativeAxisMarginToBorder * canvas.ActualWidth * 0.5);

            canvas.Children.Add(text);
        }
    }
}