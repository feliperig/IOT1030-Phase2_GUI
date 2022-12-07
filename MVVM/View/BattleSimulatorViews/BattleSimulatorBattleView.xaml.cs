using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace IOT1030_Phase2_GUI.MVVM.View.BattleSimulatorViews
{
    /// <summary>
    /// Interaction logic for BattleSimulatorBattleView.xaml
    /// </summary>
    public partial class BattleSimulatorBattleView : UserControl
    {
        public BattleSimulatorBattleView()
        {
            InitializeComponent();
        }

        private bool AutoScroll = true;

        private void BattleLog_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scrollViewer = GetScrollViewer(BattleLog);
            scrollViewer.ScrollToVerticalOffset(scrollViewer.ExtentHeight);
        }

        public static ScrollViewer GetScrollViewer(UIElement element)
        {
            if (element == null) return null;

            ScrollViewer retour = null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element) && retour == null; i++)
            {
                if (VisualTreeHelper.GetChild(element, i) is ScrollViewer)
                {
                    retour = (ScrollViewer)(VisualTreeHelper.GetChild(element, i));
                }
                else
                {
                    retour = GetScrollViewer(VisualTreeHelper.GetChild(element, i) as UIElement);
                }
            }
            return retour;
        }
    }
}
