using System.Windows.Media;

namespace plot4net.Core.Wpf
{
    /// <summary>
    ///     Performs conversion on color objects.
    /// </summary>
    public static class ColorConverter
    {
        /// <summary>
        ///     Converts a <see cref="System.Drawing.Color" /> to a <see cref="Color" />
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>The converted color.</returns>
        public static Color ToWindowsMedia(System.Drawing.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        /// <summary>
        ///     Converts a <see cref="Color" /> to a <see cref="System.Drawing.Color" />
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>The converted color.</returns>
        public static System.Drawing.Color ToSystemDrawing(Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}