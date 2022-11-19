using IOT1030_Phase2_GUI.MVVM.ViewModel;
using IOT1030_Phase2_GUI.Core;

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

        // Defining the ViewModels (objects containing code for the CurrentView)
        public HomeViewModel HomeVM;

        public MainViewModel()
        {
            InitializeViewModels();
            InitializeCommands();

            // Starting View
            CurrentView = HomeVM;
        }

        /// <summary>
        /// Initializes the view models.
        /// </summary>
        private void InitializeViewModels()
        {
            HomeVM = new HomeViewModel();
        }

        // Defining RelayCommands for UI buttons
        public RelayCommand HomeViewCommand;

        /// <summary>
        /// Initializes the RelayCommand functionality for UI buttons.
        /// </summary>
        private void InitializeCommands()
        {
            // This is how to define a command
            HomeViewCommand = new RelayCommand(o =>
            {
                // o can be referenced to get properties from the UI element that called this command!
                // Any code in here is run when this command is called
                CurrentView = HomeVM;
            });
        }
    }
}
