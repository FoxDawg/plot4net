namespace PlottingLib.Contract
{
    /// <summary>
    ///     Interface for simple plotting operations, such as title, labels, axes.
    /// </summary>
    public interface ISimplePlot
    {
        /// <summary>
        ///     Performs a simple plotting operation without any additional data.
        /// </summary>
        /// <param name="uiParent">The ui parent to plot upon.</param>
        void Plot(object uiParent);
    }
}