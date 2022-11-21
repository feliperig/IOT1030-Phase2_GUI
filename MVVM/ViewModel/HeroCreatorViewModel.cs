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
            using(XmlWriter writer = XmlWriter.Create("heroes.xml"))
            {
                writer.WriteStartElement("hero");
                writer.WriteAttributeString("name", heroName);
                writer.WriteStartElement("stats");
                writer.WriteAttributeString("Strength", stats.Find(StrengthStat);
                writer.WriteAttributeString("Intelligence", stats.Find(IntelligenceStat));
                writer.WriteAttributeString("Agility", stats.Find(AgilityStat));
                writer.WriteAttributeString("Vitality", stats.Find(VitalityStat));
                writer.WriteAttributeString("Luck", stats.Find(LuckStat));
                writer.WriteAttributeString("Magic", stats.Find(MagicStat));
                writer.WriteAttributeString("Weapon Use", stats.Find(WeaponUseStat));
                writer.WriteAttributeString("Parry", stats.Find(ParryStat));
                writer.WriteAttributeString("Dodge", stats.Find(DodgeStat));
                writer.WriteAttributeString("Stealth", stats.Find(StealthStat));
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
    }
}
