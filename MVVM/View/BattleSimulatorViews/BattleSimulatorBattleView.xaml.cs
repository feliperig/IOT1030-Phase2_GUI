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

        /// <summary>
        /// Gets the scroll viewer.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Handles the ScrollChanged event of the BattleLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ScrollChangedEventArgs"/> instance containing the event data.</param>
        private void BattleLog_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (AutoScroll)
            {
                ScrollViewer scrollViewer = GetScrollViewer(BattleLog);
                if (scrollViewer != null)
                {
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.ExtentHeight);
                }
            }
        }

        /// <summary>
        /// Handles the MouseEnter event of the BattleLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void BattleLog_MouseEnter(object sender, MouseEventArgs e)
        {
            AutoScroll = false;
        }

        /// <summary>
        /// Handles the MouseLeave event of the BattleLog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void BattleLog_MouseLeave(object sender, MouseEventArgs e)
        {
            AutoScroll = true;
        }
    }
}
