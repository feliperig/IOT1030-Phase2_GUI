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

        public StatSelectionViewModel()
        {

        }

        public void SetImagePathFromClassName(string classSelection)
        {
            ImagePath = "/Images/" + classSelection + "Sprite.png";
        }
    }
}
