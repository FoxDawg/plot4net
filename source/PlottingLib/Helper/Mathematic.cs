using System;
using System.Collections.Generic;

namespace PlottingLib.Helper
{
    /// <summary>
    ///     Helps to perform mathematic operations.
    /// </summary>
    public static class Mathematic
    {
        /// <summary>
        /// Calculates ticks for given data.
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

        /// <summary>
        ///     Checks if an array is strictly monotonic increasing.
        /// </summary>
        /// <param name="data">The data to analyze</param>
        /// <returns>True if the data are strictly monotonic increasing.</returns>
        public static bool IsMonotonicIncreasing(double[] data)
        {
            for (var i = 0; i < data.Length - 1; ++i)
            {
                if (data[i + 1] <= data[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Checks if an array is strictly monotonic decreasing.
        /// </summary>
        /// <param name="data">The data to analyze</param>
        /// <returns>True if the data are strictly monotonic decreasing.</returns>
        public static bool IsMonotonicDecreasing(double[] data)
        {
            for (var i = 0; i < data.Length - 1; ++i)
            {
                if (data[i + 1] >= data[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Calculates the optimum tick distance for a given range.
        /// </summary>
        /// <param name="range">The data range.</param>
        /// <param name="numberOfTicks">The number of steps desired.</param>
        /// <returns></returns>
        public static double CalculateTickStepSize(double range, double numberOfTicks)
        {
            // calculate an initial guess at step size
            var tempStep = range / numberOfTicks;

            // get the magnitude of the step size
            var mag = (float)Math.Floor(Math.Log10(tempStep));
            var magPow = (float)Math.Pow(10, mag);

            // calculate most significant digit of the new step size
            var magMsd = (int)(tempStep / magPow + 0.5);

            // promote the MSD to either 1, 2, or 5
            if (magMsd > 5)
                magMsd = 10;
            else if (magMsd > 2)
                magMsd = 5;
            else if (magMsd > 1)
                magMsd = 2;

            return magMsd * magPow;
        }
    }
}