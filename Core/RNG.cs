using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core
{
    public static class RNG
    {
        /// <summary>
        /// Stats to percentage.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pointsPerStep">The points required per step.</param>
        /// <param name="startPercent">The start percent.</param>
        /// <param name="percentPerStep">The percent per step.</param>
        /// <returns>Percentage as an int</returns>
        public static int StatToPercentage(int value, int pointsPerStep, int startPercent, int percentPerStep)
        {
            return value / pointsPerStep * percentPerStep + startPercent;
        }

        public static int AddRandomDeduction(int value)
        {
            return value + 1;
        }
    }
}
