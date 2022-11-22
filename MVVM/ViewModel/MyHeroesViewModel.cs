using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using IOT1030_Phase2_GUI.Core;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel
{
    class MyHeroesViewModel : ObservableObject
    {
        private ObservableCollection<HeroStats> Heroes;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyHeroesViewModel"/> class.
        /// </summary>
        public MyHeroesViewModel()
        {
            Heroes = new ObservableCollection<HeroStats>();
        }

        public void GetHeroes()
        {
            Heroes = new ObservableCollection<HeroStats>();
            foreach (string filePath in Directory.GetFiles("..\\Heroes"))
            {
                if (filePath.EndsWith(".json"))
                {
                    try
                    {
                        string jsonString = File.ReadAllText(filePath);
                        HeroStats hero = JsonSerializer.Deserialize<HeroStats>(jsonString);
                        Console.WriteLine("Found saved hero:");
                        Console.WriteLine("Name: " + hero.HeroName + "\nClass: " + hero.ClassName);
                        Console.Write("Stats: ");
                        string statsOutput = "";
                        foreach (int i in hero.Stats)
                        {
                            statsOutput += i + ",";
                        }
                        statsOutput = statsOutput.Substring(0, statsOutput.Length - 1);
                        Console.WriteLine(statsOutput);
                        Heroes.Add(hero);
                    }
                    catch
                    {
                        Console.WriteLine("Hero could not be loaded.");
                    }
                }
            }
        }
    }
}
