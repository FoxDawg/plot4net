using System.Threading.Tasks;

using plot4net.Core.Contract;
using plot4net.Core.Options;

namespace plot4net.Core
{
    /// <summary>
    ///     The main object to create a new figure.
    /// </summary>
    public class Figure
    {
        private IPlotManager plotManager;

        /// <summary>
        ///     Options for the figure to be created.
        /// </summary>
        public FigureOptions FigureOptions { get; } = new FigureOptions();

        /// <summary>
        ///     Creates a new instance of the <see cref="Figure" />
        /// </summary>
        /// <param name="options">Plot options to use.</param>
        public Figure(FigureOptions options)
        {
            this.FigureOptions = options;
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="Figure" />
        /// </summary>
        public Figure()
        {
        }

        /// <summary>
        ///     Sets the specific plot manager instance.
        /// </summary>
        /// <param name="manager">The plot manager instance to use.</param>
        public void SetManager(IPlotManager manager)
        {
            this.plotManager = manager;
        }

        /// <summary>
        ///     Adds a plot to the figure.
        /// </summary>
        /// <param name="plot">The plot to draw.</param>
        public void Plot(Plot plot)
        {
            this.plotManager.AddPlot(plot);
        }

        /// <summary>
        ///     Exports the image to the specified file.
        /// </summary>
        /// <param name="fullPath">Full path to the file.</param>
        public Task ExportAsync(string fullPath)
        {
            return this.plotManager.ExportAsync(fullPath);
        }
    }
}