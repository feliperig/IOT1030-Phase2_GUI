using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using IOT1030_Phase2_GUI.Core;

namespace IOT1030_Phase2_GUI.MVVM.ViewModel
{
    class HeroCreatorViewModel : ObservableObject
    {
        // Current page for the Hero Creator
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

        public HeroCreatorViewModel()
        {
            InitializeViewModels();

            // Starting page
            CurrentPage = ChooseClassVM;
        }

        // Defining the ViewModels
        public ChooseClassViewModel ChooseClassVM;
        public StatSelectionViewModel StatSelectionVM;

        /// <summary>
        /// Initializes the view models.
        /// </summary>
        private void InitializeViewModels()
        {
            ChooseClassVM = new ChooseClassViewModel(this);
            StatSelectionVM = new StatSelectionViewModel(this);
        }

        /// <summary>
        /// Changes the page to the stats selection page.
        /// </summary>
        /// <param name="classSelection">The class selection.</param>
        public void StatSelection(string classSelection)
        {
            StatSelectionVM.SetImagePathFromClassName(classSelection);
            CurrentPage = StatSelectionVM;
        }

        /// <summary>
        /// Creates the character using the stats and class provided
        /// returns a xml file with Hero's name and stats
        /// we can also print hero's special attacks to make it more complete
        /// </summary>
        /// <param name="stats">The stats.</param>
        /// <param name="classSelection">The class selection.</param>
        public void CreateCharacter(List<int> stats, string classSelection, string heroName)
        {
            using (XmlWriter writer = XmlWriter.Create("heroes.xml"))
            {
                writer.WriteStartElement("hero");
                writer.WriteAttributeString("name", heroName);
                writer.WriteStartElement("stats");
                writer.WriteAttributeString("Strength", stats[0].ToString());
                writer.WriteAttributeString("Intelligence", stats[1].ToString());
                writer.WriteAttributeString("Agility", stats[2].ToString());
                writer.WriteAttributeString("Vitality", stats[3].ToString());
                writer.WriteAttributeString("Luck", stats[4].ToString());
                writer.WriteAttributeString("Magic", stats[5].ToString());
                writer.WriteAttributeString("Weapon Use", stats[6].ToString());
                writer.WriteAttributeString("Parry", stats[7].ToString());
                writer.WriteAttributeString("Dodge", stats[8].ToString());
                writer.WriteAttributeString("Stealth", stats[9].ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
    }
}
