namespace plot4net.Core.Contract
{
    /// <summary>
    /// Interface for data plotting operations
    /// </summary>
    public interface IDataPlot
    {
        /// <summary>
        /// Plots two-dimensional data.
        /// </summary>
        /// <param name="uiParent">The uiParent to plot upon.</param>
        /// <param name="xData">xData to be plotted.</param>
        /// <param name="yData">yData to be plotted.</param>
        void Plot(object uiParent, double[] xData, double[] yData);
    }
}