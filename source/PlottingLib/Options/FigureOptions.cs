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
        ///     Options for the figure axes.
        /// </summary>
        public AxisOptions AxisOptions { get; set; } = new AxisOptions();

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
        public Color Background { get; set; } = Color.Gainsboro;

        /// <summary>
        ///     The figure title.
        /// </summary>
        public string Title { get; set; } = "MyFigure";

        /// <summary>
        ///     Font size for the title.
        /// </summary>
        public int TitleFontSize { get; set; } = 14;
    }
}