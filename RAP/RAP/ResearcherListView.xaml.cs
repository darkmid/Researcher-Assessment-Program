using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using RAP.Control;
using RAP.View;
using RAP.Research;
using System.Data;

namespace RAP
{
    /// <summary>
    /// Interaction logic for ResearcherListView.xaml
    /// </summary>
    public partial class ResearcherListView : UserControl
    {

        public ResearcherListView()
        {

            InitializeComponent();
            ResearcherList.ItemsSource = ResearcherController.LoadResearchers();
            ResearcherLevelBox.SelectedIndex = 0;
        }

        private void ResearcherLevelBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             ResearcherList.ItemsSource = ResearcherController.FilterBy(ResearcherLevelBox.SelectedValue);
        }

        private void ResearcherSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ResearcherList.ItemsSource = ResearcherController.FilterByName(ResearcherSearchBox.Text);
        }

        private void ResearcherList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ResearcherList.SelectedItem != null)
            {
                PublicationsController.LoadPublicationsFor((Researcher)ResearcherList.SelectedItem);
                ResearcherController.LoadResearcherDetails(ResearcherList.SelectedItem);
                ((MainWindow)Application.Current.MainWindow).UpdateResearcherDetailsView();
            }
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResearcherReportView.RRV == null)
            {
                ResearcherReportView test = new ResearcherReportView();
                test.Show();
            }
            else
            {
                ResearcherReportView.RRV.Activate();
            }
        }
    }
}
