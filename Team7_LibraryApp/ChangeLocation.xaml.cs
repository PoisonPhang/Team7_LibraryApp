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


        private string getLocationString(int id)
        {
            if (id == 1)
            {
                return "Beltsville";
            }
            else if (id == 2)
            {
                return "Champlin";
            }
            else if (id == 3)
            {
                return "Lawrence";
            }
            else if (id == 4)
            {
                return "Seattle";
            }
            else if (id == 5)
            {
                return "Clarkston";
            }
            else if (id == 6)
            {
                return "Perth Amboy";
            }
            else if (id == 7)
            {
                return "Syosset";
            }
            else if (id == 8)
            {
                return "Staunton";
            }
            else if (id == 9)
            {
                return "Manchester";
            }
            else if (id == 10)
            {
                return "Raeform";
            }
            else
            {
                return "";
            }

        }
    }
}
