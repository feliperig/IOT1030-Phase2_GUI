using IOT1030_Phase2_GUI.Core;
using IOT1030_Phase2_GUI.Core.Heroes;

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
                HeroCreatorVM.StatSelection(HeroClass.Knight);
            });
            WizardButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.StatSelection(HeroClass.Mage);
            });
            ArcherButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.StatSelection(HeroClass.Archer);
            });
            PlayerButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.StatSelection(HeroClass.Player);
            });
            KingButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.StatSelection(HeroClass.King);
            });
            QueenButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.StatSelection(HeroClass.Queen);
            });
        }

    }
}
