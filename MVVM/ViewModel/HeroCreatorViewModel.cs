using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT1030_Phase2_GUI.Core;

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

        public HeroCreatorViewModel()
        {
            InitializeViewModels();

            // Starting page
            CurrentPage = ChooseClassVM;
        }

        // Defining the ViewModels
        public ChooseClassViewModel ChooseClassVM;
        public StatSelectionViewModel StatSelectionVM;

        /// <summary>
        /// Initializes the view models.
        /// </summary>
        private void InitializeViewModels()
        {
            ChooseClassVM = new ChooseClassViewModel(this);
            StatSelectionVM = new StatSelectionViewModel(this);
        }

        /// <summary>
        /// Changes the page to the stats selection page.
        /// </summary>
        /// <param name="classSelection">The class selection.</param>
        public void StatSelection(string classSelection)
        {
            StatSelectionVM.SetImagePathFromClassName(classSelection);
            CurrentPage = StatSelectionVM;
        }

        /// <summary>
        /// Creates the character using the stats and class provided
        /// </summary>
        /// <param name="stats">The stats.</param>
        /// <param name="classSelection">The class selection.</param>
        public void CreateCharacter(List<int> stats, string classSelection, string heroName)
        {

        }
    }
}
