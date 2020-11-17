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
    /// Interaction logic for ChangeLocation.xaml
    /// </summary>
    public partial class ChangeLocation : UserControl
    {
        public ChangeLocation()
        {
            InitializeComponent();
            comboBox.SelectedIndex = Session.Location - 1;
        }

        private void buttonManageLibrary_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = this.FindAncestor<MainWindow>();
            mainWindow.SwapScreen(new ManageLibrary());
        }

        private void buttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = this.FindAncestor<MainWindow>();
            mainWindow.SwapScreen(new MainMenu());
        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = this.FindAncestor<MainWindow>();
            mainWindow.SwapScreen(new LogIn());
        }

        private void buttonChangeLocation_Click(object sender, RoutedEventArgs e)
        {

            int location = comboBox.SelectedIndex + 1;

            if (location > 0)
            {

                Session.Location = location;

                var mainWindow = this.FindAncestor<MainWindow>();
                mainWindow.SwapScreen(new MessageWindow("Location Changed to #" + comboBox.Text));
            }

      

        }
    }
}
