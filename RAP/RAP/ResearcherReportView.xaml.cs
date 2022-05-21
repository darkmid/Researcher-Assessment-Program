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
using System.Windows.Shapes;
using RAP.Control;

namespace RAP
{
    /// <summary>
    /// Interaction logic for ResearcherReportView.xaml
    /// </summary>
    public partial class ResearcherReportView : Window
    {
        public static ResearcherReportView RRV { get; set; }

        public ResearcherReportView()
        {
            InitializeComponent();
            LevelList.ItemsSource = ResearcherController.Report;
            
            
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ReporterList.ItemsSource = ResearcherController.FetchReportReseachers(LevelList.SelectedValue.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResearcherController.LoadEmails(ReporterList.SelectedItem);
        }
    }
}
