using System.Collections.Generic;

namespace PlottingLib.Helper
{
    /// <summary>
    ///     Helper methods for operations in UI logic.
    /// </summary>
    public static class FigureHelper
    {
        /// <summary>
        ///     Calculates ticks for given data.
        /// </summary>
        /// <param name="axisLimits">axis limits.</param>
        /// <param name="numberOfTicks">maximum number of ticks desired.</param>
        /// <returns></returns>
        public static double[] CalculateTicks(double[] axisLimits, int numberOfTicks)
        {
            var range = axisLimits[1] - axisLimits[0];

            var tickDistance = Mathematic.CalculateTickStepSize(range, numberOfTicks);

            var ticks = new List<double>();
            for (var i = 0; i < numberOfTicks; i++)
            {
                var newTick = axisLimits[0] + i * tickDistance;
                if (newTick <= axisLimits[1])
                {
                    ticks.Add(newTick);
                }
            }

            return ticks.ToArray();
        }
    }
}