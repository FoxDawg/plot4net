using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PlottingLib;
using PlottingLib.Contract;
using PlottingLib.Enum;
using PlottingLib.Options;

namespace TestApplication.Core.Plotter
{
    public class ScatterPlotter : IDataPlot
    {
        private readonly Canvas canvas;
        private readonly FigureOptions figureOptions;
        private readonly PlotOptions plotOptions;
        private readonly RangeExtender rangeExtender;

        public ScatterPlotter(Canvas canvas, FigureOptions figureOptions, PlotOptions plotOptions)
        {
            this.canvas = canvas;
            this.figureOptions = figureOptions;
            this.plotOptions = plotOptions;
            this.rangeExtender = new RangeExtender();
        }

        public void Plot(double[] xData, double[] yData)
        {
            var canvasWidth = this.canvas.ActualWidth;
            var canvasHeight = this.canvas.ActualHeight;

            var extendedXRangeData = xData;
            var extendedYRangeData = yData;

            if (this.plotOptions.RangeMode == RangeMode.Auto)
            {
                extendedXRangeData = this.rangeExtender.ExtendRange(xData);
                extendedYRangeData = this.rangeExtender.ExtendRange(yData);
            }

            var relativeMarginToBorder = this.figureOptions.RelativeAxisMarginToBorder;
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

                var px = Converter.FromDataToUi(xData[i], extendedXRangeData, canvasWidth, relativeMarginToBorder);
                var py = Converter.FromDataToUi(yData[i], extendedYRangeData, canvasHeight, relativeMarginToBorder);

                Canvas.SetLeft(point, px);
                Canvas.SetBottom(point, py);
                this.canvas.Children.Add(point);
            }
        }
    }
}