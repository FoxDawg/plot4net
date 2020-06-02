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
        void Plot();
    }
}