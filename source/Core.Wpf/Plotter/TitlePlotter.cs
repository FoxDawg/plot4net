using System;
using System.Windows;
using System.Windows.Controls;

using plot4net.Core.Contract;
using plot4net.Core.Options;

namespace plot4net.Core.Wpf.Plotter
{
    /// <summary>
    /// Specific plotter for the title bar.
    /// </summary>
    internal class TitlePlotter : ISimplePlot
    {
        private readonly FigureOptions options;

        /// <summary>
        /// Creates a new instance of the <see cref="TitlePlotter" />
        /// </summary>
        /// <param name="options">The figure options to use.</param>
        public TitlePlotter(FigureOptions options)
        {
            this.options = options;
        }

        /// <summary>
        /// Performs a simple plotting operation without any additional data.
        /// </summary>
        /// <param name="uiParent">The ui parent to plot upon.</param>
        public void Plot(object uiParent)
        {
            if (uiParent is Canvas canvas)
            {
                var text = new Label
                {
                    Content = this.options.Title,
                    Margin = new Thickness(0),
                    Width = canvas.ActualWidth,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    FontSize = this.options.TitleFontSize
                };

                Canvas.SetTop(text, 0.25 * this.options.AxisOptions.RelativeAxisMarginToBorder * canvas.ActualHeight);
                Canvas.SetLeft(text, 0);

                canvas.Children.Add(text);
            }
            else
            {
                throw new ArgumentException($"UiParent must be of type {typeof(Canvas)}.");
            }
        }
    }
}