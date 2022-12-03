using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using IOT1030_Phase2_GUI.Core;
using IOT1030_Phase2_GUI.Core.Heroes;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel
{
    class MyHeroesViewModel : ObservableObject
    {
        /// <summary>
        /// The heroes data provided to the datagrid
        /// </summary>
        private ObservableCollection<Hero> _heroes;
        public ObservableCollection<Hero> Heroes
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
            Heroes = new ObservableCollection<Hero>();
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
                foreach(Hero hero in Heroes)
                {
                    if(hero.Name == (string)o)
                    {
                        mainVM.ShowHeroDisplay(hero);
                        break;
                    }
                }
            });
        }

        /// <summary>
        /// Gets the heroes from the Heroes folder and loads them into the Heroes list.
        /// Deserializes saved Json Hero objects.
        /// </summary>
        public void GetHeroes()
        {
            ObservableCollection<Hero> heroes = new ObservableCollection<Hero>();
            foreach (string filePath in Directory.GetFiles("..\\Heroes"))
            {
                if (filePath.EndsWith(".json"))
                {
                    try
                    {
                        string jsonString = File.ReadAllText(filePath);
                        JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
                        Hero hero = JsonSerializer.Deserialize<Hero>(jsonString, options);

                        heroes.Add(hero);
                    }
                    catch
                    {
                        Console.WriteLine("Hero could not be loaded.");
                    }
                }
            }
            Heroes = heroes;
        }
    }
}
