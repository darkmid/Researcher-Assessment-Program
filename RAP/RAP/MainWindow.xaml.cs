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
using RAP.Database;
using RAP.Control;

namespace RAP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResearcherDetailsView.IsEnabled = false;
            PublicationDetailsView.IsEnabled = false;
        }

        public void UpdateResearcherDetailsView()
        {
            if (ResearcherController.CurrentResearcher != null)
            {
                ResearcherDetailsView.DataContext = ResearcherController.CurrentResearcher;
                ResearcherDetailsView.IsEnabled = true;


                PublicationListView.PublicationList.ItemsSource =
                    PublicationsController.LoadPublicationsFor(ResearcherController.CurrentResearcher);
                PublicationListView.YearFrom.ItemsSource = PublicationsController.PublicationYears;
                PublicationListView.YearTo.ItemsSource = PublicationsController.PublicationYears;
            }
            
        }

        public void UpdatePublicationDetailsView()
        {
            if (PublicationsController.CurrentPublication != null)
            {
                PublicationDetailsView.DataContext = PublicationsController.CurrentPublication;
                PublicationDetailsView.IsEnabled = true;
            }
        }

        private void PublicationListView_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
