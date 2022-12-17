using IOT1030_Phase2_GUI.Core;
using IOT1030_Phase2_GUI.Core.Heroes;
using System.Windows;
using System.Linq;
using System.Collections.Generic;
using IOT1030_Phase2_GUI.MVVM.ViewModel.BattleSimulatorViewModels;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel
{
    /// <summary>
    /// Defines the functionality for the MainView which contains the Title, Page Buttons, and the Current Page
    /// </summary>
    /// <seealso cref="IOT1030_Phase2_GUI.Core.ObservableObject" />
    class MainViewModel : ObservableObject
    {
        // Current view to display
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                // Make sure to call this to inform the UI that this property has changed
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            InitializeViewModels();
            InitializeCommands();

            // Starting View
            CurrentView = HomeVM;
        }

        // Defining the ViewModels (objects containing code for the CurrentView)
        public HomeViewModel HomeVM;
        public HeroCreatorViewModel HeroCreatorVM;
        public MyHeroesViewModel MyHeroesVM;
        public HeroDisplayViewModel HeroDisplayVM;
        public BattleSimulatorMainViewModel BattleSimulatorVM;

        /// <summary>
        /// Initializes the view models.
        /// </summary>
        private void InitializeViewModels()
        {
            HomeVM = new HomeViewModel();
            HeroCreatorVM = new HeroCreatorViewModel();
            HeroDisplayVM = new HeroDisplayViewModel(this);
            MyHeroesVM = new MyHeroesViewModel(this);
            BattleSimulatorVM = new BattleSimulatorMainViewModel();
        }

        // Defining RelayCommands for UI buttons
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand HeroCreatorViewCommand { get; set; }
        public RelayCommand MyHeroesViewCommand { get; set; }
        public RelayCommand BattleSimulatorViewCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        

        /// <summary>
        /// Initializes the RelayCommand functionality for UI buttons.
        /// </summary>
        private void InitializeCommands()
        {
            // This is how to define a command
            CloseWindowCommand = new RelayCommand(o =>
            {
                // o can be referenced to get properties from the UI object that called this command!
                // Any code in here is run when this command is called
                Application.Current.MainWindow.Close();
            });
            MinimizeWindowCommand = new RelayCommand(o =>
            {
                Application.Current.MainWindow.WindowState = WindowState.Minimized;
            });

            // Page button commands
            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;   // sets current page to "Home"
            });
            HeroCreatorViewCommand = new RelayCommand(o =>
            {
                CurrentView = HeroCreatorVM;    // sets current page to "Hero Creator"
            });
            MyHeroesViewCommand = new RelayCommand(o =>
            {
                MyHeroesVM.GetHeroes(); // get heroes created list
                CurrentView = MyHeroesVM; // sets current page to "My Heroes"
            });
            BattleSimulatorViewCommand = new RelayCommand(o =>
            {
                CurrentView = BattleSimulatorVM; // sets current page to "Battle Simulator"
            });
        }

        /// <summary>
        /// Shows the hero display page.
        /// </summary>
        /// <param name="hero">Object containing hero's stats, class and name</param>
        public void ShowHeroDisplay(Hero hero)
        {
            // Get values from hero
            string heroName = hero.Name;
            HeroClass heroClass = hero.HeroClass;
            List<int> statsList = hero.Stats.Values.ToList();

            // Set values in hero display
            HeroDisplayVM.HeroName = heroName;
            HeroDisplayVM.SetStatsList(statsList);
            HeroDisplayVM.SetImagePathFromClassName(heroClass);
            HeroDisplayVM.GetHeroClass(heroClass);

            // change page to hero display
            CurrentView = HeroDisplayVM;
        }

        /// <summary>
        /// Goes back to my heroes page.
        /// </summary>
        public void GoBackToMyHeroes()
        {
            CurrentView = MyHeroesVM;
        }
    }
}
