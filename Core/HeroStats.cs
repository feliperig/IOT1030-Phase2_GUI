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
        public List<int> Stats { get; set; }    // list of hero stats
        public string HeroName { get; set; }    // hero given name
        public string ClassName { get; set; }   // hero class
        public string ImagePath                 // hero image
        {
            get
            {
                return "/Images/" + ClassName + "Sprite.png";
            }
        }

        public HeroStats(List<int> stats, string heroName, string className) 
        {
            this.Stats = stats;
            this.HeroName = heroName;
            this.ClassName = className;
        }

        public HeroStats()
        {
            Stats = new List<int>
            {
                5,5,5,5,5,5,5,5,5,5
            };
            HeroName = "None";
            ClassName = "None";
        }
    }
}
