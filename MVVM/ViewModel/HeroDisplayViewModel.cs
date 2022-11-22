using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IOT1030_Phase2_GUI.Core;

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
                "Description 4"
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
            }
        }

        /// <summary>
        /// Get list of stats from created hero
        /// </summary>
        /// <param name="heroName">Hero name for stats</param>
        public void GetStatsList(string heroName) 
        { 

        }
    }
}
