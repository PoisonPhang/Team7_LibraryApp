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

namespace Team7_LibraryApp
{
    /// <summary>
    /// Interaction logic for ReportFour.xaml
    /// </summary>
    public partial class ReportFour : UserControl
    {
        private MainWindow mainWindow;

        public ReportFour(MainWindow m)
        {
            InitializeComponent();
            mainWindow = m;
        }

        private void buttonMainMenu_Click(object sender, RoutedEventArgs e)
        {

            var mainWindow = this.FindAncestor<MainWindow>();
            mainWindow.SwapScreen(new MainMenu());

        }

        private void buttonReports_Click(object sender, RoutedEventArgs e)
        {

            var mainWindow = this.FindAncestor<MainWindow>();
            mainWindow.SwapScreen(new Reports());

        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {

            var mainWindow = this.FindAncestor<MainWindow>();
            mainWindow.SwapScreen(new LogIn());

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                string startDate = StartDate.SelectedDate.Value.ToString("yyyy-MM-dd");
                string endDate = EndDate.SelectedDate.Value.ToString("yyyy-MM-dd");


                listViewRankLibraryReport.ItemsSource = mainWindow.dataRepo.GetLibraryRankReports(startDate, endDate);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
