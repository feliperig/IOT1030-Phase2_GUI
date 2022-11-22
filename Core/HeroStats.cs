using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.Core
{
    class HeroStats
    {
        public List<int> Stats { get; set; }

        public string _heroName;

        public string _className;

        public HeroStats(List<int> stats, string heroName, string className) 
        {
            Stats = new List<int>();
        }
    }
}
