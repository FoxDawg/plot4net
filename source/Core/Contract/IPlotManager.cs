using System.Threading.Tasks;

namespace plot4net.Core.Contract
{
    /// <summary>
    /// Manages plotting operations for a given figure.
    /// </summary>
    public interface IPlotManager
    {
        /// <summary>
        /// Add a specific plot to an existing figure.
        /// </summary>
        /// <param name="plot">The plot to draw.</param>
        void AddPlot(Plot plot);

        /// <summary>
        /// Exports a figure to a file.
        /// </summary>
        /// <param name="fullPath">Full path to the file.</param>
        Task ExportAsync(string fullPath);
    }
}