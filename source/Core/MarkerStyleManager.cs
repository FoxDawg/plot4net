using System.Collections.Generic;
using System.Drawing;

namespace plot4net.Core
{
    /// <summary>
    /// Manages plot line and marker colors.
    /// </summary>
    public class MarkerStyleManager
    {
        /// <summary>
        /// The set of default line colors.
        /// </summary>
        public IList<Color> LineColors { get; } = new List<Color>
        {
            Color.Black,
            Color.DodgerBlue,
            Color.DarkOrange,
            Color.DarkRed,
            Color.DarkGreen,
            Color.Gold
        };

        private int currentColorIndex;

        /// <summary>
        /// Returns the next available color.
        /// </summary>
        /// <returns>Color value.</returns>
        public Color Next()
        {
            var color = this.LineColors[this.currentColorIndex++];
            if (this.currentColorIndex >= this.LineColors.Count)
            {
                this.currentColorIndex = 0;
            }

            return color;
        }
    }
}