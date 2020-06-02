namespace PlottingLib.Contract
{
    /// <summary>
    ///     Interface for data plotting operations
    /// </summary>
    public interface IDataPlot
    {
        /// <summary>
        ///     Plots two-dimensional data.
        /// </summary>
        /// <param name="xData">xData to be plotted.</param>
        /// <param name="yData">yData to be plotted.</param>
        void Plot(double[] xData, double[] yData);
    }
}