﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IOT1030_Phase2_GUI.Core;
using IOT1030_Phase2_GUI.Core.Heroes;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel
{
    class HeroDisplayViewModel : ObservableObject
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
        /// The hero name
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

        private string _classSelection;
        public string ClassSelection
        {
            get { return _classSelection; }
            set
            {
                _classSelection = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _attackNames;
        public ObservableCollection<string> AttackNames
        {
            get { return _attackNames; }
            set
            {
                _attackNames = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<int> _statsList;
        public ObservableCollection<int> StatsList
        {
            get { return _statsList; }
            set
            {
                _statsList = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The parent ViewModel
        /// </summary>
        private object ParentVM;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroDisplayViewModel"/> class.
        /// </summary>
        /// <param name="ParentVM">The parent vm.</param>
        public HeroDisplayViewModel(object ParentVM)
        {
            this.ParentVM = ParentVM;
            InitializeCommands();
            _attackDescriptions = new List<string>
            {
                "Description 1",
                "Description 2",
                "Description 3",
                "Description 4",
                "Description 5"
            };
        }

        /// <summary>
        /// Defining the RelayCommands for the buttons
        /// </summary>
        public RelayCommand GoBackButtonCommand { get; set; }
        public RelayCommand DescriptionButtonCommand { get; set; }

        /// <summary>
        /// Initializes the RelayCommands for the buttons
        /// </summary>
        private void InitializeCommands()
        {
            GoBackButtonCommand = new RelayCommand(o =>
            {
                GoBackButton();
            });

            DescriptionButtonCommand = new RelayCommand(o => 
            {
                int index = int.Parse((string)o);
                DescriptionButton(index);
            });
        }

        private string _descriptionText;
        public string DescriptionText
        {
            get { return _descriptionText; }
            set
            {
                _descriptionText = value;
                OnPropertyChanged();
            }
        }

        private List<string> _attackDescriptions;

        /// <summary>
        /// Description for character attack
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void DescriptionButton(int index)
        {
            if (index > _attackDescriptions.Count - 1)
                return;
            DescriptionText = _attackDescriptions[index];
        }

        /// <summary>
        /// Function for the go back button
        /// </summary>
        private void GoBackButton()
        {
            if(ParentVM.GetType() == typeof(HeroCreatorViewModel))
            {
                HeroCreatorViewModel HeroCreatorVM = (HeroCreatorViewModel)ParentVM;
                HeroCreatorVM.GoBackToChooseClass();
            }else if (ParentVM.GetType() == typeof(MainViewModel))
            {
                MainViewModel MainVM = (MainViewModel)ParentVM;
                MainVM.GoBackToMyHeroes();
            }
        }

        /// <summary>
        /// Get list of stats from created hero
        /// </summary>
        /// <param name="heroName">Hero name for stats</param>
        public void GetStatsList(string heroName) 
        {

        }

        /// <summary>
        /// Sets the stats list using List<int>
        /// </summary>
        /// <param name="stats">The stats.</param>
        public void SetStatsList(List<int> stats)
        {
            StatsList = new ObservableCollection<int>();
            foreach(int i in stats)
            {
                StatsList.Add(i);
            }
        }

        /// <summary>
        /// Gets the stats list as a List<int>
        /// </summary>
        /// <returns></returns>
        private List<int> GetStatsList()
        {
            List<int> returnList = new List<int>();
            foreach(int i in StatsList)
            {
                returnList.Add(i);
            }
            return returnList;
        }

        /// <summary>
        /// Converts a List<string> to ObservableCollection<string>
        /// </summary>
        /// <param name="stringList">The string list.</param>
        /// <returns></returns>
        private ObservableCollection<string> StringListToCollection(List<string> stringList)
        {
            ObservableCollection<string> returnList = new ObservableCollection<string>();
            foreach(string str in stringList)
            {
                returnList.Add(str);
            }

            if(returnList.Count < 5)
            {
                for(int i = returnList.Count; i <= 5; i++)
                {
;                    returnList.Add("");
                }
            }
            return returnList;
        }

        /// <summary>
        /// Sets the name of the image path from the selected class name.
        /// </summary>
        /// <param name="classSelection">The class selection.</param>
        public void SetImagePathFromClassName(string classSelection)
        {
            ClassSelection = classSelection;
            ImagePath = "/Images/" + classSelection + "Sprite.png";
        }

        /// <summary>
        /// Gets the hero class from the class selection
        /// </summary>
        /// <param name="classSelection">The class selection.</param>
        public void GetHeroClass(string classSelection)
        {
            classSelection = classSelection.ToLower();
            Hero hero = new Player(GetStatsList(), HeroName);
            switch (classSelection)
            {
                case "wizard":
                    hero = new Mage(GetStatsList(), HeroName);
                    break;
                case "knight":
                    hero = new Knight(GetStatsList(), HeroName);
                    break;
                case "king":
                    hero = new King(GetStatsList(), HeroName);
                    break;
                case "queen":
                    hero = new Queen(GetStatsList(), HeroName);
                    break;
                case "archer":
                    hero = new Archer(GetStatsList(), HeroName);
                    break;
                default:
                    break;
            }

            AttackNames = StringListToCollection(hero.GetAttackNames());
            _attackDescriptions = hero.GetAttackDescriptions();
            DescriptionText = _attackDescriptions[0];
        }
    }
}
