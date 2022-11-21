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


        private int _strengthStat = 5;
        public string StrengthStat
        {
            get { return "" + _strengthStat; }
            set
            {
                try
                {
                    _strengthStat = int.Parse(value);
                }
                catch
                {
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
                    _intelligenceStat = int.Parse(value);
                }
                catch
                {
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
                    _agilityStat = int.Parse(value);
                }
                catch
                {
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
                    _vitalityStat = int.Parse(value);
                }
                catch
                {
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
                    _luckStat = int.Parse(value);
                }
                catch
                {
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
                    _magicStat = int.Parse(value);
                }
                catch
                {
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
                    _weaponUseStat = int.Parse(value);
                }
                catch
                {
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
                    _parryStat = int.Parse(value);
                }
                catch
                {
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
                    _dodgeStat = int.Parse(value);
                }
                catch
                {
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
                    _stealthStat = int.Parse(value);
                }
                catch
                {
                    _stealthStat = 0;
                }
                OnPropertyChanged();
            }
        }

        private List<int> _heroStats = new List<int>() 
        {
            StrengthStat,
            IntelligenceStat,
            AgilityStat,
            VitalityStat,
            LuckStat,
            MagicStat,
            WeaponUseStat,
            ParryStat,
            DodgeStat,
            StealthStat
        };

        private string _classSelection;
        private HeroCreatorViewModel HeroCreatorVM;

        public StatSelectionViewModel(HeroCreatorViewModel HeroCreatorVM)
        {
            this.HeroCreatorVM = HeroCreatorVM;
            InitializeCommands();
        }

        public RelayCommand CreateCharacterButtonCommand { get; set; }

        public void InitializeCommands()
        {
            CreateCharacterButtonCommand = new RelayCommand(o =>
            {
                HeroCreatorVM.CreateCharacter(_heroStats, _classSelection);
            });
        }

        public void SetImagePathFromClassName(string classSelection)
        {
            this.classSelection = classSelection;
            ImagePath = "/Images/" + classSelection + "Sprite.png";
        }
    }
}
