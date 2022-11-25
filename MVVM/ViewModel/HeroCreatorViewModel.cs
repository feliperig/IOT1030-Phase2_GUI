using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using IOT1030_Phase2_GUI.Core;
using IOT1030_Phase2_GUI.Core.Heroes;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel
{
    class HeroCreatorViewModel : ObservableObject
    {
        // Current page for the Hero Creator
        private object _currentPage;
        public object CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroCreatorViewModel"/> class.
        /// </summary>
        public HeroCreatorViewModel()
        {
            InitializeViewModels();

            // Starting page
            CurrentPage = ChooseClassVM;
        }

        // Defining the ViewModels
        private ChooseClassViewModel ChooseClassVM;
        private StatSelectionViewModel StatSelectionVM;
        private HeroDisplayViewModel HeroDisplayVM; 

        /// <summary>
        /// Initializes the view models.
        /// </summary>
        private void InitializeViewModels()
        {
            ChooseClassVM = new ChooseClassViewModel(this);
            StatSelectionVM = new StatSelectionViewModel(this);
            HeroDisplayVM = new HeroDisplayViewModel(this);
        }

        /// <summary>
        /// Goes the back to choose class page.
        /// </summary>
        public void GoBackToChooseClass()
        {
            CurrentPage = ChooseClassVM;
        }

        /// <summary>
        /// Changes the page to the stats selection page.
        /// </summary>
        /// <param name="classSelection">The class selection.</param>
        public void StatSelection(string classSelection)
        {
            StatSelectionVM.ClearStats();
            StatSelectionVM.SetImagePathFromClassName(classSelection);
            CurrentPage = StatSelectionVM;
        }

        /// <summary>
        /// Creates the character using the stats and class provided
        /// returns a xml file with Hero's name and stats
        /// we can also print hero's special attacks to make it more complete
        /// </summary>
        /// <param name="stats">The stats.</param>
        /// <param name="classSelection">The class selection.</param>
        public void CreateCharacter(List<int> stats, string classSelection, string heroName)
        {
            if (!IsValidHeroName(heroName))
                return;
            if (!Directory.Exists("../Heroes"))
            {
                Directory.CreateDirectory("../Heroes");
            };

            HeroStats hero = new HeroStats(stats, heroName, classSelection);
            string jsonString = JsonSerializer.Serialize(hero);
            File.WriteAllText("../Heroes/" + heroName + ".json", jsonString);

            ObservableCollection<int> StatsList = new ObservableCollection<int>
            {
                stats[0],
                stats[1],
                stats[2],
                stats[3],
                stats[4],
                stats[5],
                stats[6],
                stats[7],
                stats[8],
                stats[9],
            };
            HeroDisplayVM.StatsList = StatsList;
            HeroDisplayVM.HeroName = heroName;
            HeroDisplayVM.SetImagePathFromClassName(classSelection);
            HeroDisplayVM.GetHeroClass(classSelection);
            CurrentPage = HeroDisplayVM;
        }

        /// <summary>
        /// Determines whether [is valid hero name] [the specified hero name].
        /// </summary>
        /// <param name="heroName">Name of the hero.</param>
        /// <returns>
        ///   <c>true</c> if [is valid hero name] [the specified hero name]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsValidHeroName(string heroName)
        {
            if (string.IsNullOrEmpty(heroName))
            {
                MessageBox.Show("You cannot have a blank hero name!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (heroName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                MessageBox.Show("Your hero name contains an invalid character!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (File.Exists("../Heroes/" + heroName + ".json"))
            {
                var result = MessageBox.Show("A hero already exists with this name.\nWould you like to overwrite it?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                    return false;
            }

            return true;
        }
    }
}
