using IOT1030_Phase2_GUI.Core;
using IOT1030_Phase2_GUI.Core.Heroes;
using IOT1030_Phase2_GUI.Core.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel.BattleSimulatorViewModels
{
    class BattleSimulatorMainViewModel : ObservableObject
    {
        // Current page for the Battle Simulator
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

        // Defining page view models
        private BattleSimulatorSetupViewModel SetupVM;
        private BattleSimulatorBattleViewModel BattleVM;

        public BattleSimulatorMainViewModel()
        {
            InitializeViewModels();
            CurrentPage = SetupVM;
        }

        /// <summary>
        /// Initializes the view models.
        /// </summary>
        private void InitializeViewModels()
        {
            SetupVM = new BattleSimulatorSetupViewModel(this);
            BattleVM = new BattleSimulatorBattleViewModel(this);
        }

        /// <summary>
        /// Starts the battle.
        /// </summary>
        /// <param name="hero">The hero.</param>
        /// <param name="monster">The monster.</param>
        public void StartBattle(Hero hero, Monster monster)
        {
            BattleVM.StartBattle(hero, monster);
            CurrentPage = BattleVM;
        }
    }
}
