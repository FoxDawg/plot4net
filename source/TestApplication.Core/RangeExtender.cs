using System.Collections.Generic;
using System.Linq;

namespace TestApplication.Core
{
    public class RangeExtender
    {
        public double[] ExtendRange(double[] data)
        {
            var dataRange = data.Max() - data.Min();
            var extendedData = new List<double>();
            extendedData.Add(data.Min() - 0.1 * dataRange);
            extendedData.AddRange(data);
            extendedData.Add(data.Max() + 0.1 * dataRange);

            return extendedData.ToArray();
        }
    }
}