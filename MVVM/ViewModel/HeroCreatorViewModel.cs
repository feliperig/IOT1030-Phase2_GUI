using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
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
        public void StatSelection(HeroClass classSelection)
        {
            StatSelectionVM.ClearStats();
            StatSelectionVM.SetImagePathFromClassName(classSelection);
            CurrentPage = StatSelectionVM;
        }

        /// <summary>
        /// Creates the character using the stats and class provided
        /// Writes the resulting Hero to a Json file in the Heroes folder
        /// Then loads the HeroDisplay Page with the newly created Hero's values
        /// </summary>
        /// <param name="stats">The stats.</param>
        /// <param name="classSelection">The class selection.</param>
        public void CreateCharacter(List<int> stats, HeroClass classSelection, string heroName)
        {
            if (!IsValidHeroName(heroName))
                return;
            if (!Directory.Exists("../Heroes"))
            {
                Directory.CreateDirectory("../Heroes");
            };

            // Create hero object using classSelection
            Hero hero = new Player(stats, heroName);
            switch (classSelection)
            {
                case HeroClass.Archer:
                    hero = new Archer(stats, heroName);
                    break;
                case HeroClass.Queen:
                    hero = new Queen(stats, heroName);
                    break;
                case HeroClass.Mage:
                    hero = new Mage(stats, heroName);
                    break;
                case HeroClass.King:
                    hero = new King(stats, heroName);
                    break;
                case HeroClass.Knight:
                    hero = new Knight(stats, heroName);
                    break;
            }

            // Serialize to json string and write to file
            JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(hero, options);
            File.WriteAllText("../Heroes/" + heroName + ".json", jsonString);

            // Set values in the hero display page
            HeroDisplayVM.SetStatsList(stats);
            HeroDisplayVM.HeroName = heroName;
            HeroDisplayVM.SetImagePathFromClassName(classSelection);
            HeroDisplayVM.GetHeroClass(classSelection);

            // Change page to hero display
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
