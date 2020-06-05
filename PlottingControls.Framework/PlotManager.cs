using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using PlottingControls.Framework.Plotter;
using PlottingLib;
using PlottingLib.Contract;
using PlottingLib.Helper;
using PlottingLib.Options;

namespace PlottingControls.Framework
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

        /// <summary>
        ///     Creates a new instance of <see cref="PlotManager" />
        /// </summary>
        /// <param name="canvas">The canvas to plot upon.</param>
        /// <param name="figureOptions">The figure options to use.</param>
        public PlotManager(Canvas canvas, FigureOptions figureOptions)
        {
            this.canvas = canvas ?? throw new ArgumentNullException(nameof(canvas));
            this.figureOptions = figureOptions ?? throw new ArgumentNullException(nameof(figureOptions));
            this.figureExporter = new FigureExporter(this.canvas, this.figureOptions.RendererType, this.figureOptions.RendererResolution);
        }

        /// <summary>
        ///     Add a specific plot to an existing figure.
        /// </summary>
        /// <param name="plot">The plot to draw.</param>
        public void AddPlot(Plot plot)
        {
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

        /// <summary>
        ///     Exports a figure to a file.
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