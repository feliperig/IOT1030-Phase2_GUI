using IOT1030_Phase2_GUI.Core;
using IOT1030_Phase2_GUI.Core.Heroes;
using IOT1030_Phase2_GUI.Core.Monsters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel.BattleSimulatorViewModels
{
    class BattleSimulatorSetupViewModel : ObservableObject
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
        /// The heroes data provided to the datagrid
        /// </summary>
        private ObservableCollection<Monster> _monsters;
        public ObservableCollection<Monster> Monsters
        {
            get { return _monsters; }
            set
            {
                _monsters = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The selected hero
        /// </summary>
        private Hero _selectedHero;
        public Hero SelectedHero
        {
            get { return _selectedHero; }
            set 
            { 
                _selectedHero = value;
                BattleButtonEnabled = SelectedMonster != null && SelectedHero != null;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The selected monster
        /// </summary>
        private Monster _selectedMonster;
        public Monster SelectedMonster
        {
            get { return _selectedMonster; }
            set 
            { 
                _selectedMonster = value;
                BattleButtonEnabled = SelectedMonster != null && SelectedHero != null;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets a value indicating whether [battle button enabled].
        /// </summary>
        private bool _battleButtonEnabled;
        public bool BattleButtonEnabled 
        {
            get { return _battleButtonEnabled; }
            set
            {
                _battleButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The main vm for the battle simulator
        /// </summary>
        private BattleSimulatorMainViewModel _mainVM;
        public BattleSimulatorSetupViewModel(BattleSimulatorMainViewModel mainVM) 
        {
            Heroes = new ObservableCollection<Hero>();
            _mainVM = mainVM;
            UpdateLists();
            InitializeCommands();
        }

        /// <summary>
        /// Defining the button commands
        /// </summary>
        public RelayCommand SelectHeroCommand { get; set; }
        public RelayCommand SelectMonsterCommand { get; set; }
        public RelayCommand BattleButtonCommand { get; set; }

        /// <summary>
        /// Initializes the commands.
        /// </summary>
        private void InitializeCommands()
        {
            SelectHeroCommand = new RelayCommand(o =>
            {
                SelectedHero = (Hero)o;
            });
            SelectMonsterCommand = new RelayCommand(o =>
            {
                SelectedMonster = (Monster)o;
            });
            BattleButtonCommand = new RelayCommand(o =>
            {
                _mainVM.StartBattle(SelectedHero, SelectedMonster);
            });
        }

        /// <summary>
        /// Updates the hero and monster lists.
        /// </summary>
        public void UpdateLists() 
        {
            GetHeroes();
            GetMonsters();
        }

        /// <summary>
        /// Gets the heroes from the Heroes folder and loads them into the Heroes list.
        /// Deserializes saved Json Hero objects.
        /// </summary>
        private void GetHeroes()
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

        /// <summary>
        /// Gets the monsters.
        /// </summary>
        private void GetMonsters()
        {
            Monsters = new ObservableCollection<Monster>
            {
                new Goblin(),
                new Orc(),
                new ZombieBear()
            };
        }
    }
}
