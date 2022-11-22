using IOT1030_Phase2_GUI.MVVM.ViewModel;
using IOT1030_Phase2_GUI.Core;
using System.Windows;

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

        /// <summary>
        /// Initializes the view models.
        /// </summary>
        private void InitializeViewModels()
        {
            HomeVM = new HomeViewModel();
            HeroCreatorVM = new HeroCreatorViewModel();
            HeroDisplayVM = new HeroDisplayViewModel(this);
            MyHeroesVM = new MyHeroesViewModel(this);
        }

        // Defining RelayCommands for UI buttons
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand HeroCreatorViewCommand { get; set; }
        public RelayCommand MyHeroesViewCommand { get; set; }

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
                CurrentView = HomeVM;
            });
            HeroCreatorViewCommand = new RelayCommand(o =>
            {
                CurrentView = HeroCreatorVM;
            });
            MyHeroesViewCommand = new RelayCommand(o =>
            {
                MyHeroesVM.GetHeroes();
                CurrentView = MyHeroesVM;
            });
        }

        /// <summary>
        /// Shows the hero display.
        /// </summary>
        /// <param name="hero">The hero.</param>
        public void ShowHeroDisplay(HeroStats hero)
        {
            HeroDisplayVM.HeroName = hero.HeroName;
            HeroDisplayVM.SetStatsList(hero.Stats);
            HeroDisplayVM.SetImagePathFromClassName(hero.ClassName);
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
