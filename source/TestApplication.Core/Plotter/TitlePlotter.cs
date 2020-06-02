using System.Windows;
using System.Windows.Controls;
using PlottingLib.Contract;
using PlottingLib.Options;

namespace TestApplication.Core.Plotter
{
    public class TitlePlotter : ISimplePlot
    {
        private readonly Canvas canvas;
        private readonly FigureOptions options;

        public TitlePlotter(Canvas canvas, FigureOptions options)
        {
            this.canvas = canvas;
            this.options = options;
        }

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