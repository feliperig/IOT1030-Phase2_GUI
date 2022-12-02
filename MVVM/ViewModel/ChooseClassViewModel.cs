using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT1030_Phase2_GUI.Core;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel
{
    class ChooseClassViewModel : ObservableObject
    {
        // Reference to the parent ViewModel to relay page changing commands
        private HeroCreatorViewModel HeroCreatorVM;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChooseClassViewModel"/> class.
        /// </summary>
        /// <param name="HeroCreatorVM">The hero creator vm.</param>
        public ChooseClassViewModel(HeroCreatorViewModel HeroCreatorVM)
        {
            InitializeCommands();
            this.HeroCreatorVM = HeroCreatorVM;
        }

        // Defining the RelayCommands for the buttons
        public RelayCommand KnightButtonCommand { get; set; }
        public RelayCommand KingButtonCommand { get; set; }
        public RelayCommand QueenButtonCommand { get; set; }
        public RelayCommand WizardButtonCommand { get; set; }
        public RelayCommand ArcherButtonCommand { get; set; }
        public RelayCommand PlayerButtonCommand { get; set; }

        /// <summary>
        /// Initializes the commands.
        /// </summary>
        private void InitializeCommands()
        {
            KnightButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.StatSelection("Knight");
            });
            WizardButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.StatSelection("Wizard");
            });
            ArcherButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.StatSelection("Archer");
            });
            PlayerButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.StatSelection("Player");
            });
            KingButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.StatSelection("King");
            });
            QueenButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.StatSelection("Queen");
            });
        }

    }
}
