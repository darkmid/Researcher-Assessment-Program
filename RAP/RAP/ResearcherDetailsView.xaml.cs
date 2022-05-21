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

namespace RAP
{
    /// <summary>
    /// Interaction logic for ResearcherDetailsView.xaml
    /// </summary>
    public partial class ResearcherDetailsView : UserControl
    {
        public ResearcherDetailsView()
        {
            InitializeComponent();
        }

        private void ShowName_Click(object sender, RoutedEventArgs e)
        {
            if (SuperviseesListView.SLV == null)
            {
                SuperviseesListView test = new SuperviseesListView();
                test.Show();
            }
            else
            {
                SuperviseesListView.SLV.Activate();
            }
        }

        private void CumulativeCount_Click(object sender, RoutedEventArgs e)
        {
            if (CumulativeCountView.CCV == null)
            {
                CumulativeCountView test = new CumulativeCountView();
                test.Show();
            }
            else
            {
                CumulativeCountView.CCV.Activate();
            }
        }
    }
}
