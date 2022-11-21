using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT1030_Phase2_GUI.Core;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel
{
    class StatSelectionViewModel : ObservableObject
    {
        /// <summary>
        /// The image path for the class icon
        /// </summary>
        private object _imagePath;
        public object ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The hero's name
        /// </summary>
        private string _heroName;
        public string HeroName
        {
            get { return _heroName; }
            set
            {
                _heroName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Character Stats
        /// </summary>
        private int _strengthStat = 5;
        public string StrengthStat
        {
            get { return "" + _strengthStat; }
            set
            {
                try
                {
                    int newValue = int.Parse(value);
                    if (newValue < 1)
                        newValue = 1;
                    RemainingPoints = "" + (_remainingPoints + (_strengthStat - newValue));
                    _strengthStat = newValue;
                }
                catch
                {
                    RemainingPoints = "" + (_remainingPoints + _strengthStat);
                    _strengthStat = 0;
                }
                OnPropertyChanged();
            }
        }

        private int _intelligenceStat = 5;
        public string IntelligenceStat
        {
            get { return "" + _intelligenceStat; }
            set
            {
                try
                {
                    int newValue = int.Parse(value);
                    if (newValue < 1)
                        newValue = 1;
                    RemainingPoints = "" + (_remainingPoints + (_intelligenceStat - newValue));
                    _intelligenceStat = newValue;
                }
                catch
                {
                    RemainingPoints = "" + (_remainingPoints + _intelligenceStat);
                    _intelligenceStat = 0;
                }
                OnPropertyChanged();
            }
        }

        private int _agilityStat = 5;
        public string AgilityStat
        {
            get { return "" + _agilityStat; }
            set
            {
                try
                {
                    int newValue = int.Parse(value);
                    if (newValue < 1)
                        newValue = 1;
                    RemainingPoints = "" + (_remainingPoints + (_agilityStat - newValue));
                    _agilityStat = newValue;
                }
                catch
                {
                    RemainingPoints = "" + (_remainingPoints + _agilityStat);
                    _agilityStat = 0;
                }
                OnPropertyChanged();
            }
        }

        private int _vitalityStat = 5;
        public string VitalityStat
        {
            get { return "" + _vitalityStat; }
            set
            {
                try
                {
                    int newValue = int.Parse(value);
                    if (newValue < 1)
                        newValue = 1;
                    RemainingPoints = "" + (_remainingPoints + (_vitalityStat - newValue));
                    _vitalityStat = newValue;
                }
                catch
                {
                    RemainingPoints = "" + (_remainingPoints + _vitalityStat);
                    _vitalityStat = 0;
                }
                OnPropertyChanged();
            }
        }

        private int _luckStat = 5;
        public string LuckStat
        {
            get { return "" + _luckStat; }
            set
            {
                try
                {
                    int newValue = int.Parse(value);
                    if (newValue < 1)
                        newValue = 1;
                    RemainingPoints = "" + (_remainingPoints + (_luckStat - newValue));
                    _luckStat = newValue;
                }
                catch
                {
                    RemainingPoints = "" + (_remainingPoints + _luckStat);
                    _luckStat = 0;
                }
                OnPropertyChanged();
            }
        }

        private int _magicStat = 5;
        public string MagicStat
        {
            get { return "" + _magicStat; }
            set
            {
                try
                {
                    int newValue = int.Parse(value);
                    if (newValue < 1)
                        newValue = 1;
                    RemainingPoints = "" + (_remainingPoints + (_magicStat - newValue));
                    _magicStat = newValue;
                }
                catch
                {
                    RemainingPoints = "" + (_remainingPoints + _magicStat);
                    _magicStat = 0;
                }
                OnPropertyChanged();
            }
        }

        private int _weaponUseStat = 5;
        public string WeaponUseStat
        {
            get { return "" + _weaponUseStat; }
            set
            {
                try
                {
                    int newValue = int.Parse(value);
                    if (newValue < 1)
                        newValue = 1;
                    RemainingPoints = "" + (_remainingPoints + (_weaponUseStat - newValue));
                    _weaponUseStat = newValue;
                }
                catch
                {
                    RemainingPoints = "" + (_remainingPoints + _weaponUseStat);
                    _weaponUseStat = 0;
                }
                OnPropertyChanged();
            }
        }

        private int _parryStat = 5;
        public string ParryStat
        {
            get { return "" + _parryStat; }
            set
            {
                try
                {
                    int newValue = int.Parse(value);
                    if (newValue < 1)
                        newValue = 1;
                    RemainingPoints = "" + (_remainingPoints + (_parryStat - newValue));
                    _parryStat = newValue;
                }
                catch
                {
                    RemainingPoints = "" + (_remainingPoints + _parryStat);
                    _parryStat = 0;
                }
                OnPropertyChanged();
            }
        }

        private int _dodgeStat = 5;
        public string DodgeStat
        {
            get { return "" + _dodgeStat; }
            set
            {
                try
                {
                    int newValue = int.Parse(value);
                    if (newValue < 1)
                        newValue = 1;
                    RemainingPoints = "" + (_remainingPoints + (_dodgeStat - newValue));
                    _dodgeStat = newValue;
                }
                catch
                {
                    RemainingPoints = "" + (_remainingPoints + _dodgeStat);
                    _dodgeStat = 0;
                }
                OnPropertyChanged();
            }
        }

        private int _stealthStat = 5;
        public string StealthStat
        {
            get { return "" + _stealthStat; }
            set
            {
                try
                {
                    int newValue = int.Parse(value);
                    if (newValue < 1)
                        newValue = 1;
                    RemainingPoints = "" + (_remainingPoints + (_stealthStat - newValue));
                    _stealthStat = newValue;
                }
                catch
                {
                    RemainingPoints = "" + (_remainingPoints + _stealthStat);
                    _stealthStat = 0;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The remaining points left to allocate
        /// </summary>
        private int _remainingPoints = 5;
        public string RemainingPoints
        {
            get { return "" + _remainingPoints; }
            set
            {
                try
                {
                    _remainingPoints = int.Parse(value);
                }
                catch
                {
                    _remainingPoints = 0;
                }
                if (_remainingPoints < 0)
                    _remainingPoints = 0;

                if (_remainingPoints == 0)
                {
                    CanCreateCharacter = true;
                    CanEditStat= false;
                }
                else
                {
                    CanCreateCharacter = false;
                    CanEditStat = true;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Enables edit buttons
        /// </summary>
        private bool _canEditStat;
        public bool CanEditStat
        {
            get { return _canEditStat; }
            set
            {
                _canEditStat = value; 
                OnPropertyChanged();
            }
        }
        private bool _canCreateCharacter;

        /// <summary>
        /// Enables the "Create Character" button
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can create character; otherwise, <c>false</c>.
        /// </value>
        public bool CanCreateCharacter
        {
            get { return _canCreateCharacter; }
            set
            {
                _canCreateCharacter = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The class selection
        /// </summary>
        private string classSelection;

        /// <summary>
        /// Defining the ViewModels
        /// </summary>
        private HeroCreatorViewModel HeroCreatorVM;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatSelectionViewModel"/> class.
        /// </summary>
        /// <param name="HeroCreatorVM">The hero creator vm.</param>
        public StatSelectionViewModel(HeroCreatorViewModel HeroCreatorVM)
        {
            this.HeroCreatorVM = HeroCreatorVM;
            InitializeCommands();
        }

        /// <summary>
        /// Defining the RelayCommands for the buttons
        /// </summary>
        public RelayCommand CreateCharacterButtonCommand { get; set; }
        public RelayCommand EditStatButtonCommand { get; set; }
        public RelayCommand CancelButtonCommand { get; set; }

        /// <summary>
        /// Initializes the commands for the button RelayCommands
        /// </summary>
        public void InitializeCommands()
        {
            CreateCharacterButtonCommand = new RelayCommand(o =>
            {
                List<int> stats = new List<int>
                {
                    _strengthStat,
                    _intelligenceStat,
                    _agilityStat,
                    _vitalityStat,
                    _luckStat,
                    _magicStat,
                    _weaponUseStat,
                    _parryStat,
                    _dodgeStat,
                    _stealthStat
                };
                HeroCreatorVM.CreateCharacter(stats, classSelection, HeroName);
            });
            EditStatButtonCommand = new RelayCommand(o =>
            {
                string buttonName = (string)o;
                int amountToAdd = 0;
                if (buttonName.StartsWith("Plus"))
                    amountToAdd = 1;
                else if (buttonName.StartsWith("Minus"))
                    amountToAdd = -1;

                if(buttonName.EndsWith("Strength"))
                    StrengthStat = "" + (_strengthStat + amountToAdd);
                else if (buttonName.EndsWith("Intelligence"))
                    IntelligenceStat = "" + (_intelligenceStat + amountToAdd);
                else if (buttonName.EndsWith("Agility"))
                    AgilityStat = "" + (_agilityStat + amountToAdd);
                else if (buttonName.EndsWith("Vitality"))
                    VitalityStat = "" + (_vitalityStat + amountToAdd);
                else if (buttonName.EndsWith("Luck"))
                    LuckStat = "" + (_luckStat + amountToAdd);
                else if (buttonName.EndsWith("Magic"))
                    MagicStat = "" + (_magicStat + amountToAdd);
                else if (buttonName.EndsWith("WeaponUse"))
                    WeaponUseStat = "" + (_weaponUseStat + amountToAdd);
                else if (buttonName.EndsWith("Parry"))
                    ParryStat = "" + (_parryStat + amountToAdd);
                else if (buttonName.EndsWith("Dodge"))
                    DodgeStat = "" + (_dodgeStat + amountToAdd);
                else if (buttonName.EndsWith("Stealth"))
                    StealthStat = "" + (_stealthStat + amountToAdd);
            });
            CancelButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.GoBackToChooseClass();
            });
        }

        /// <summary>
        /// Sets the name of the image path from the selected class name.
        /// </summary>
        /// <param name="classSelection">The class selection.</param>
        public void SetImagePathFromClassName(string classSelection)
        {
            this.classSelection = classSelection;
            ImagePath = "/Images/" + classSelection + "Sprite.png";
        }

        /// <summary>
        /// Clears the stats.
        /// </summary>
        public void ClearStats()
        {
            StrengthStat = "5";
            IntelligenceStat = "5";
            AgilityStat = "5";
            VitalityStat = "5";
            LuckStat = "5";
            MagicStat = "5";
            WeaponUseStat = "5";
            ParryStat = "5";
            DodgeStat = "5";
            StealthStat = "5";
        }
    }
}
