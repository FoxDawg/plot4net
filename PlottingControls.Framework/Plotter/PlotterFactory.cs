using System.Collections.Generic;
using PlottingLib.Contract;
using PlottingLib.Enum;
using PlottingLib.Options;

namespace PlottingControls.Framework.Plotter
{
    /// <summary>
    ///     Creates plotter for the specified configurations.
    /// </summary>
    public class PlotterFactory
    {
        private readonly FigureOptions figureOptions;

        /// <summary>
        /// Creates a new instance of <see cref="PlotterFactory"/>
        /// </summary>
        /// <param name="figureOptions">Figure options to use.</param>
        public PlotterFactory(FigureOptions figureOptions)
        {
            this.figureOptions = figureOptions ?? new FigureOptions();
        }

        /// <summary>
        /// Creates a set of SimplePlotter instances.
        /// </summary>
        /// <returns>A list of plotters.</returns>
        public IEnumerable<ISimplePlot> Create()
        {
            yield return new AxisPlotter(this.figureOptions.AxisOptions);
            yield return new AxisTickPlotter(this.figureOptions.AxisOptions);
            yield return new AxisLabelPlotter(this.figureOptions.AxisOptions);
            

            if (!string.IsNullOrEmpty(this.figureOptions.Title))
            {
                yield return new TitlePlotter(this.figureOptions);
            }
        }

        /// <summary>
        /// Creates a set of DataPlotter instances.
        /// </summary>
        /// <returns>A list of plotters.</returns>
        public IEnumerable<IDataPlot> Create(PlotOptions options)
        {
            switch (options.LineType)
            {
                case LineType.Line:
                    yield return new LinePlotter(this.figureOptions.AxisOptions, options);
                    break;
                case LineType.Scatter:
                    yield return new ScatterPlotter(this.figureOptions.AxisOptions, options);
                    break;
                case LineType.ScatterAndLine:
                    yield return new LinePlotter(this.figureOptions.AxisOptions, options);
                    yield return new ScatterPlotter(this.figureOptions.AxisOptions, options);
                    break;
            }
        }
    }
}