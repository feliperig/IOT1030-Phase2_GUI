using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT1030_Phase2_GUI.Core;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel
{
    class HeroDisplayViewModel : ObservableObject
    {
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
        }

        /// <summary>
        /// Defining the RelayCommands for the buttons
        /// </summary>
        public RelayCommand GoBackButtonCommand { get; set; }

        /// <summary>
        /// Initializes the RelayCommands for the buttons
        /// </summary>
        private void InitializeCommands()
        {
            GoBackButtonCommand = new RelayCommand(o =>
            {
                GoBackButton();
            });
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
    }
}
