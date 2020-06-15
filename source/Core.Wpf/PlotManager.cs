using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

using plot4net.Core.Contract;
using plot4net.Core.Enum;
using plot4net.Core.Helper;
using plot4net.Core.Options;
using plot4net.Core.Wpf.Plotter;

namespace plot4net.Core.Wpf
{
    /// <summary>
    /// Plot manager for wpf plotting operations.
    /// </summary>
    public class PlotManager : IPlotManager
    {
        private readonly Canvas canvas;
        private readonly FigureExporter figureExporter;

        private readonly FigureOptions figureOptions;

        private readonly IList<Plot> plots = new List<Plot>();
        private readonly MarkerStyleManager markerStyleManager;

        /// <summary>
        /// Creates a new instance of <see cref="PlotManager" />
        /// </summary>
        /// <param name="canvas">The canvas to plot upon.</param>
        /// <param name="figureOptions">The figure options to use.</param>
        public PlotManager(Canvas canvas, FigureOptions figureOptions)
        {
            this.canvas = canvas ?? throw new ArgumentNullException(nameof(canvas));
            this.figureOptions = figureOptions ?? throw new ArgumentNullException(nameof(figureOptions));
            this.figureExporter = new FigureExporter(this.canvas, this.figureOptions.RendererType, this.figureOptions.RendererResolution);
            this.markerStyleManager = new MarkerStyleManager();
        }

        /// <summary>
        /// Add a specific plot to an existing figure.
        /// </summary>
        /// <param name="plot">The plot to draw.</param>
        public void AddPlot(Plot plot)
        {
            this.MatchColors(plot.PlotOptions);

            this.plots.Add(plot);

            var mergedXData = this.plots.SelectMany(o => o.XData).ToArray();
            var mergedYData = this.plots.SelectMany(o => o.YData).ToArray();

            RangeExtender.ExtendHorizontalRange(mergedXData, this.figureOptions.AxisOptions);
            RangeExtender.ExtendVerticalRange(mergedYData, this.figureOptions.AxisOptions);
            RangeExtender.SetHorizontalAxisTicks(this.figureOptions.AxisOptions);
            RangeExtender.SetVerticalAxisTicks(this.figureOptions.AxisOptions);

            this.canvas.Children.Clear();
            this.canvas.Background = new SolidColorBrush(ColorConverter.ToWindowsMedia(this.figureOptions.Background));

            var factory = new PlotterFactory(this.figureOptions);

            this.PerformSimplePlots(factory);

            foreach (var currentPlot in this.plots)
            {
                this.PerformDataPlots(factory, currentPlot);
            }
        }

        private void MatchColors(PlotOptions options)
        {
            if (options.LineColor == default)
            {
                var nextColor = this.markerStyleManager.Next();
                options.LineColor = nextColor;
                options.MarkerColor = nextColor;
                return;
            }

            if (options.LineColor == default && options.MarkerColor != default && (options.LineType == LineType.Line || options.LineType == LineType.ScatterAndLine))
            {
                options.LineColor = options.MarkerColor;
                return;
            }

            if (options.MarkerColor == default && options.LineColor != default && (options.LineType == LineType.Scatter || options.LineType == LineType.ScatterAndLine))
            {
                options.MarkerColor = options.LineColor;
            }
        }

        /// <summary>
        /// Exports a figure to a file.
        /// </summary>
        /// <param name="fullPath">Full path to the file.</param>
        public Task ExportAsync(string fullPath)
        {
            return this.figureExporter.ExportToFileAsync(fullPath);
        }

        private void PerformSimplePlots(PlotterFactory factory)
        {
            var simplePlotter = factory.Create();

            foreach (var simplePlot in simplePlotter)
            {
                simplePlot.Plot(this.canvas);
            }
        }

        private void PerformDataPlots(PlotterFactory factory, Plot plot)
        {
            var dataPlotter = factory.Create(plot.PlotOptions);

            foreach (var dataPlot in dataPlotter)
            {
                dataPlot.Plot(this.canvas, plot.XData, plot.YData);
            }
        }
    }
}