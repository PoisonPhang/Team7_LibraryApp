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
        public ReportFour()
        {
            InitializeComponent();
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
    }
}
