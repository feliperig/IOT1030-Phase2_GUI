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
using IOT1030_Phase2_GUI.Core.Heroes;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel
{
    class MyHeroesViewModel : ObservableObject
    {
        /// <summary>
        /// The heroes data provided to the datagrid
        /// </summary>
        private ObservableCollection<HeroStats> _heroes;
        public ObservableCollection<HeroStats> Heroes
        {
            get { return _heroes; }
            set
            {
                _heroes = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Reference to the parent ViewModel to relay page changing commands
        /// </summary>
        private MainViewModel mainVM;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyHeroesViewModel"/> class.
        /// </summary>
        public MyHeroesViewModel(MainViewModel mainVM)
        {
            this.mainVM = mainVM;
            Heroes = new ObservableCollection<HeroStats>();
            InitializeCommands();
        }

        // Defining button commands
        public RelayCommand HeroDisplayCommand { get; set; }

        /// <summary>
        /// Initializes the commands.
        /// </summary>
        private void InitializeCommands()
        {
            HeroDisplayCommand = new RelayCommand(o =>
            {
                foreach(HeroStats hero in Heroes)
                {
                    if(hero.HeroName == (string)o)
                    {
                        mainVM.ShowHeroDisplay(hero);
                        break;
                    }
                }
            });
        }

        /// <summary>
        /// Gets the heroes.
        /// </summary>
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
