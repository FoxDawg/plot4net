using System.Windows.Media;

namespace TestApplication.Core
{
    public static class ColorConverter
    {
        public static Color ToWindowsMedia(System.Drawing.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static System.Drawing.Color ToSystemDrawing(Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}