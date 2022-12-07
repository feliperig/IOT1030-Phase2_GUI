using IOT1030_Phase2_GUI.Core;
using IOT1030_Phase2_GUI.Core.Heroes;
using IOT1030_Phase2_GUI.Core.MonsterAttacks;
using IOT1030_Phase2_GUI.Core.Monsters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel.BattleSimulatorViewModels
{
    class BattleSimulatorBattleViewModel : ObservableObject
    {
        /// <summary>
        /// The hero
        /// </summary>
        private Hero _hero;
        public Hero Hero
        {
            get { return _hero; }
            set 
            { 
                _hero = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The hero health bar width
        /// </summary>
        private int _heroHealthBarWidth;
        public int HeroHealthBarWidth
        {
            get { return _heroHealthBarWidth; }
            set 
            { 
                _heroHealthBarWidth = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The monster
        /// </summary>
        private Monster _monster;
        public Monster Monster
        {
            get { return _monster; }
            set 
            { 
                _monster = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The monster health bar width
        /// </summary>
        private int _monsterHealthBarWidth;
        public int MonsterHealthBarWidth
        {
            get { return _monsterHealthBarWidth; }
            set 
            { 
                _monsterHealthBarWidth = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The details box title
        /// </summary>
        private string _detailsTitle = "Details";
        public string DetailsTitle
        {
            get { return _detailsTitle; }
            set 
            { 
                _detailsTitle = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The details box text
        /// </summary>
        private string _detailsText;
        public string DetailsText
        {
            get { return _detailsText; }
            set 
            { 
                _detailsText = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// My attacks list
        /// </summary>
        private ObservableCollection<Attack> _myAttacks;
        public ObservableCollection<Attack> MyAttacks
        {
            get { return _myAttacks; }
            set 
            { 
                _myAttacks = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Monster attacks list
        /// </summary>
        private ObservableCollection<MonsterAttack> _monsterAttacks;
        public ObservableCollection<MonsterAttack> MonsterAttacks
        {
            get { return _monsterAttacks; }
            set
            {
                _monsterAttacks = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The selected attack
        /// </summary>
        private Attack _selectedAttack;
        public Attack SelectedAttack
        {
            get { return _selectedAttack; }
            set 
            {
                _selectedAttack = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The main vm for the battle simulator
        /// </summary>
        private BattleSimulatorMainViewModel _mainVM;
        public BattleSimulatorBattleViewModel(BattleSimulatorMainViewModel mainVM)
        {
            _mainVM = mainVM;
            MyAttacks = new ObservableCollection<Attack>();
            MonsterAttacks = new ObservableCollection<MonsterAttack>();
            InitializeCommands();
        }

        /// <summary>
        /// Starts the battle.
        /// </summary>
        /// <param name="hero">The hero.</param>
        /// <param name="monster">The monster.</param>
        public void StartBattle(Hero hero, Monster monster)
        {
            Hero = hero;
            Monster = monster;
            MyAttacks = new ObservableCollection<Attack>();
            MonsterAttacks = new ObservableCollection<MonsterAttack>();
            foreach (Attack attack in Hero.Attacks)
            {
                _myAttacks.Add(attack);
            }
            foreach (MonsterAttack monsterAttack in Monster.Attacks)
            {
                _monsterAttacks.Add(monsterAttack);
            }
            CalculateHealthBarWidth();
        }

        /// <summary>
        /// Calculates the health bar witdth for Monster and Hero
        /// </summary>
        public void CalculateHealthBarWidth()
        {
            MonsterHealthBarWidth = (int)(178 * ((float)Monster.CurrentHealth / (float)Monster.MaxHealth));
            HeroHealthBarWidth = (int)(178 * ((float)Hero.CurrentHealth / (float)Hero.MaxHealth));
        }

        public RelayCommand ArmourButtonCommand { get; set; }
        public RelayCommand WeaponButtonCommand { get; set; }
        public RelayCommand StatsButtonCommand { get; set; }
        public RelayCommand InventoryButtonCommand { get; set; }
        public RelayCommand MonsterAttackButtonCommand { get; set; }
        public RelayCommand HeroAttackButtonCommand { get; set; }
        private void InitializeCommands()
        {
            ArmourButtonCommand = new RelayCommand(o =>
            {
                DetailsTitle = "Equipped Armour";
                DetailsText = $"Armour Name: {Hero.EquippedArmour.Name}\nProtection: {Hero.EquippedArmour.Protection}";
            });
            WeaponButtonCommand = new RelayCommand(o =>
            {
                DetailsTitle = "Equipped Weapon";
                DetailsText = $"Weapon Name: {Hero.EquippedWeapon.Name}\nDamage: {Hero.EquippedWeapon.Damage}";
            });
            StatsButtonCommand = new RelayCommand(o =>
            {
                string detailsText = "";
                for(int i = 0; i < Hero.Stats.Count; i++)
                {
                    string statName = ((Stats)i).ToString();

                    detailsText += $"{statName}: {Hero.GetStat((Stats)i)}";

                    if(i % 2 == 1)
                    {
                        detailsText += "\n";
                    }
                    else
                    {
                        int lineLength = statName.Length + Hero.GetStat((Stats)i).ToString().Length + 1;
                        if (lineLength < 15)
                        {
                            for(int j = lineLength; j < 15; j++)
                            {
                                detailsText += " ";
                            }
                        }
                        detailsText += "\t";
                    }
                }
                DetailsTitle = "Hero Stats";
                DetailsText = detailsText;
            });
            MonsterAttackButtonCommand = new RelayCommand(o =>
            {
                MonsterAttack monsterAttack = (MonsterAttack)o;
                DetailsTitle = monsterAttack.Name;
                DetailsText = monsterAttack.Description;
            });
            HeroAttackButtonCommand = new RelayCommand(o =>
            {
                Attack attack = (Attack)o;
                SelectedAttack = attack;
            });
        }
    }
}
