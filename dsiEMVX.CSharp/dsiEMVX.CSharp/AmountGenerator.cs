using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsiEMVX.CSharp
{
    public class AmountGenerator
    {
        private static readonly Random random = new Random();

        public static string GenerateAmount(double min, double max)
        {
            var val = RandomNumberBetween(min, max);

            return String.Format("{0:0.00}", val);
        }

        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }
    }
}
