using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT1030_Phase2_GUI.Core;
using IOT1030_Phase2_GUI.Core.Heroes;

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
        /// Strength stat with some input sanitizing functionality
        /// </summary>
        private int _strengthStat = 5;
        public string StrengthStat
        {
            get { return "" + _strengthStat; }
            set
            {
                if(value.Length < 3)
                {
                    try
                    {
                        int newValue = int.Parse(value);
                        if (newValue < 1)
                            newValue = 1;
                        RemainingPoints = "" + (_remainingPoints + (_strengthStat - newValue));
                        if (_remainingPoints < 0)
                        {
                            newValue += _remainingPoints;
                            RemainingPoints = "0";
                        }
                        _strengthStat = newValue;
                    }
                    catch
                    {
                        RemainingPoints = "" + (_remainingPoints + _strengthStat - 1);
                        _strengthStat = 1;
                    }
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Intelligence stat with some input sanitizing functionality
        /// </summary>
        private int _intelligenceStat = 5;
        public string IntelligenceStat
        {
            get { return "" + _intelligenceStat; }
            set
            {
                if (value.Length < 3)
                {
                    try
                    {
                        int newValue = int.Parse(value);
                        if (newValue < 1)
                            newValue = 1;
                        RemainingPoints = "" + (_remainingPoints + (_intelligenceStat - newValue));
                        if (_remainingPoints < 0)
                        {
                            newValue += _remainingPoints;
                            RemainingPoints = "0";
                        }
                        _intelligenceStat = newValue;
                    }
                    catch
                    {
                        RemainingPoints = "" + (_remainingPoints + _intelligenceStat - 1);
                        _intelligenceStat = 1;
                    }
                    OnPropertyChanged();
                }
                
            }
        }

        /// <summary>
        /// Agility stat with some input sanitizing functionality
        /// </summary>
        private int _agilityStat = 5;
        public string AgilityStat
        {
            get { return "" + _agilityStat; }
            set
            {
                if (value.Length < 3)
                {
                    try
                    {
                        int newValue = int.Parse(value);
                        if (newValue < 1)
                            newValue = 1;
                        RemainingPoints = "" + (_remainingPoints + (_agilityStat - newValue));
                        if (_remainingPoints < 0)
                        {
                            newValue += _remainingPoints;
                            RemainingPoints = "0";
                        }
                        _agilityStat = newValue;
                    }
                    catch
                    {
                        RemainingPoints = "" + (_remainingPoints + _agilityStat - 1);
                        _agilityStat = 1;
                    }
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Vitality stat with some input sanitizing functionality
        /// </summary>
        private int _vitalityStat = 5;
        public string VitalityStat
        {
            get { return "" + _vitalityStat; }
            set
            {
                if (value.Length < 3)
                {
                    try
                    {
                        int newValue = int.Parse(value);
                        if (newValue < 1)
                            newValue = 1;
                        RemainingPoints = "" + (_remainingPoints + (_vitalityStat - newValue));
                        if (_remainingPoints < 0)
                        {
                            newValue += _remainingPoints;
                            RemainingPoints = "0";
                        }
                        _vitalityStat = newValue;
                    }
                    catch
                    {
                        RemainingPoints = "" + (_remainingPoints + _vitalityStat - 1);
                        _vitalityStat = 1;
                    }
                    OnPropertyChanged();
                }
            }
                    
        }

        /// <summary>
        /// Luck stat with some input sanitizing functionality
        /// </summary>
        private int _luckStat = 5;
        public string LuckStat
        {
            get { return "" + _luckStat; }
            set
            {
                if (value.Length < 3)
                {
                    try
                    {
                        int newValue = int.Parse(value);
                        if (newValue < 1)
                            newValue = 1;
                        RemainingPoints = "" + (_remainingPoints + (_luckStat - newValue));
                        if (_remainingPoints < 0)
                        {
                            newValue += _remainingPoints;
                            RemainingPoints = "0";
                        }
                        _luckStat = newValue;
                    }
                    catch
                    {
                        RemainingPoints = "" + (_remainingPoints + _luckStat - 1);
                        _luckStat = 1;
                    }
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Magic stat with some input sanitizing functionality
        /// </summary>
        private int _magicStat = 5;
        public string MagicStat
        {
            get { return "" + _magicStat; }
            set
            {
                if (value.Length < 3)
                {
                    try
                    {
                        int newValue = int.Parse(value);
                        if (newValue < 1)
                            newValue = 1;
                        RemainingPoints = "" + (_remainingPoints + (_magicStat - newValue));
                        if (_remainingPoints < 0)
                        {
                            newValue += _remainingPoints;
                            RemainingPoints = "0";
                        }
                        _magicStat = newValue;
                    }
                    catch
                    {
                        RemainingPoints = "" + (_remainingPoints + _magicStat - 1);
                        _magicStat = 1;
                    }
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Weapon Use stat with some input sanitizing functionality
        /// </summary>
        private int _weaponUseStat = 5;
        public string WeaponUseStat
        {
            get { return "" + _weaponUseStat; }
            set
            {
                if (value.Length < 3)
                {
                    try
                    {
                        int newValue = int.Parse(value);
                        if (newValue < 1)
                            newValue = 1;
                        RemainingPoints = "" + (_remainingPoints + (_weaponUseStat - newValue));
                        if (_remainingPoints < 0)
                        {
                            newValue += _remainingPoints;
                            RemainingPoints = "0";
                        }
                        _weaponUseStat = newValue;
                    }
                    catch
                    {
                        RemainingPoints = "" + (_remainingPoints + _weaponUseStat - 1);
                        _weaponUseStat = 1;
                    }
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Parry stat with some input sanitizing functionality
        /// </summary>
        private int _parryStat = 5;
        public string ParryStat
        {
            get { return "" + _parryStat; }
            set
            {
                if (value.Length < 3)
                {
                    try
                    {
                        int newValue = int.Parse(value);
                        if (newValue < 1)
                            newValue = 1;
                        RemainingPoints = "" + (_remainingPoints + (_parryStat - newValue));
                        if (_remainingPoints < 0)
                        {
                            newValue += _remainingPoints;
                            RemainingPoints = "0";
                        }
                        _parryStat = newValue;
                    }
                    catch
                    {
                        RemainingPoints = "" + (_remainingPoints + _parryStat - 1);
                        _parryStat = 1;
                    }
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Dodge stat with some input sanitizing functionality
        /// </summary>
        private int _dodgeStat = 5;
        public string DodgeStat
        {
            get { return "" + _dodgeStat; }
            set
            {
                if (value.Length < 3)
                {
                    try
                    {
                        int newValue = int.Parse(value);
                        if (newValue < 1)
                            newValue = 1;
                        RemainingPoints = "" + (_remainingPoints + (_dodgeStat - newValue));
                        if (_remainingPoints < 0)
                        {
                            newValue += _remainingPoints;
                            RemainingPoints = "0";
                        }
                        _dodgeStat = newValue;
                    }
                    catch
                    {
                        RemainingPoints = "" + (_remainingPoints + _dodgeStat - 1);
                        _dodgeStat = 1;
                    }
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Stealth stat with some input sanitizing functionality
        /// </summary>
        private int _stealthStat = 5;
        public string StealthStat
        {
            get { return "" + _stealthStat; }
            set
            {
                if (value.Length < 3)
                {
                    try
                    {
                        int newValue = int.Parse(value);
                        if (newValue < 1)
                            newValue = 1;
                        RemainingPoints = "" + (_remainingPoints + (_stealthStat - newValue));
                        if(_remainingPoints < 0)
                        {
                            newValue += _remainingPoints;
                            RemainingPoints = "0";
                        }
                        _stealthStat = newValue;
                    }
                    catch
                    {
                        RemainingPoints = "" + (_remainingPoints + _stealthStat - 1);
                        _stealthStat = 1;
                    }
                    OnPropertyChanged();
                }
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

                if (_remainingPoints == 0)
                {
                    CanCreateCharacter = true;
                }
                else
                {
                    CanCreateCharacter = false;
                }

                if(_remainingPoints <= 0)
                {
                    CanEditStat = false;
                }
                else
                {
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
        private HeroClass _classSelection;

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
                HeroCreatorVM.CreateCharacter(stats, _classSelection, HeroName);
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
        public void SetImagePathFromClassName(HeroClass classSelection)
        {
            _classSelection = classSelection;
            ImagePath = "/Images/" + classSelection.ToString() + "Sprite.png";
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
            HeroName = "";
        }
    }
}
