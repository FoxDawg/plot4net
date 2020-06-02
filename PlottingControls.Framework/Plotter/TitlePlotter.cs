using System.Windows;
using System.Windows.Controls;
using PlottingLib.Contract;
using PlottingLib.Options;

namespace PlottingControls.Framework.Plotter
{
    /// <summary>
    ///     Specific plotter for the title bar.
    /// </summary>
    public class TitlePlotter : ISimplePlot
    {
        private readonly Canvas canvas;
        private readonly FigureOptions options;

        /// <summary>
        ///     Creates a new instance of the <see cref="TitlePlotter" />
        /// </summary>
        /// <param name="canvas">The canvas to draw upon.</param>
        /// <param name="options">The figure options to use.</param>
        public TitlePlotter(Canvas canvas, FigureOptions options)
        {
            this.canvas = canvas;
            this.options = options;
        }

        /// <summary>
        ///     Performs a simple plotting operation without any additional data.
        /// </summary>
        public void Plot()
        {
            var text = new Label
            {
                Content = this.options.Title,
                Margin = new Thickness(0),
                Width = this.canvas.ActualWidth,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };

            Canvas.SetTop(text, 0.25 * this.options.RelativeAxisMarginToBorder * this.canvas.ActualHeight);
            Canvas.SetLeft(text, 0);

            this.canvas.Children.Add(text);
        }
    }
}