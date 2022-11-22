using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core
{
    public class HeroStats
    {
        public List<int> stats { get; set; }
        public string heroName { get; set; }
        public string className { get; set; }

        public HeroStats(List<int> stats, string heroName, string className) 
        {
            this.stats = stats;
            this.heroName = heroName;
            this.className = className;
        }

        public HeroStats()
        {
            stats = new List<int>
            {
                5,5,5,5,5,5,5,5,5,5
            };
            heroName = "None";
            className = "None";
        }
    }
}
