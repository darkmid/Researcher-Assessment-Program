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
using RAP.Control;

namespace RAP
{
    /// <summary>
    /// Interaction logic for PublicationListView.xaml
    /// </summary>
    public partial class PublicationListView : UserControl
    {
        public PublicationListView()
        {
            
            InitializeComponent();
            
        }

        private void PublicationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PublicationsController.LoadCurrentPublicationDetails(PublicationList.SelectedItem);
            ((MainWindow)Application.Current.MainWindow).UpdatePublicationDetailsView();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int from;
            int to;
            int swap;

            if (ResearcherController.CurrentResearcher != null)
            {
                if (YearFrom.Text == "")
                {
                    from = ResearcherController.CurrentResearcher.EarliestStart.Year;
                }
                else
                {
                    int.TryParse(YearFrom.Text, out from);
                }

                if (YearTo.Text == "")
                {
                    to = DateTime.Today.Year;
                }
                else
                {
                    int.TryParse(YearTo.Text, out to);
                }

                if (from > to)
                {
                    swap = from;
                    from = to;
                    to = swap;
                }

                PublicationList.ItemsSource = PublicationsController.FilterBy(from, to);
            }
        }
    }
}
