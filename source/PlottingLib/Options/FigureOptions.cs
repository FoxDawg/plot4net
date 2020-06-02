using System.Drawing;
using PlottingLib.Enum;

namespace PlottingLib.Options
{
    /// <summary>
    ///     Data object to hold figure options.
    /// </summary>
    public class FigureOptions
    {
        /// <summary>
        ///     The relative margin of the plot to the border on both sides.
        /// </summary>
        public double RelativeAxisMarginToBorder { get; set; } = 0.1;

        /// <summary>
        ///     The renderer type used for image export.
        /// </summary>
        public RendererType RendererType { get; set; } = RendererType.Png;

        /// <summary>
        ///     The renderer resolution used for image export.
        /// </summary>
        public double RendererResolution { get; set; } = 150;

        /// <summary>
        ///     The figure background color.
        /// </summary>
        public Color Background { get; set; } = Color.AntiqueWhite;

        /// <summary>
        ///     The figure title.
        /// </summary>
        public string Title { get; set; } = "MyFigure";
    }
}