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
    /// Interaction logic for ReportTwo.xaml
    /// </summary>
    public partial class ReportTwo : UserControl
    {
        private MainWindow mainWindow;

        public ReportTwo(MainWindow m)
        {
            InitializeComponent();
            mainWindow = m;

            listViewMostPopularBooksReport.ItemsSource = mainWindow.dataRepo.GetBookRankReports(1);

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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int genre = SelectGenre.SelectedIndex + 2;
                listViewMostPopularBooksReport.ItemsSource = mainWindow.dataRepo.GetBookRankReports(genre);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
