using plot4net.Core.Options;

namespace plot4net.Core
{
    /// <summary>
    /// A simple two dimensional plot.
    /// </summary>
    public class Plot
    {
        /// <summary>
        /// Horizontal data to plot.
        /// </summary>
        public double[] XData { get; }

        /// <summary>
        /// Vertical data to plot.
        /// </summary>
        public double[] YData { get; }

        /// <summary>
        /// Plot options to use.
        /// </summary>
        public PlotOptions PlotOptions { get; }

        /// <summary>
        /// Creates a new instance of <see cref="Plot" />
        /// </summary>
        /// <param name="xData">Horizontal data to plot</param>
        /// <param name="yData">Vertical data to plot</param>
        /// <param name="plotOptions">Plot options to use</param>
        public Plot(double[] xData, double[] yData, PlotOptions plotOptions)
        {
            this.XData = xData;
            this.YData = yData;
            this.PlotOptions = plotOptions;
        }
    }
}