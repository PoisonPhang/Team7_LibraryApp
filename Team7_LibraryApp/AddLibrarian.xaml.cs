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
    /// Interaction logic for AddLibrarian.xaml
    /// </summary>
    public partial class AddLibrarian : UserControl
    {
        public AddLibrarian()
        {
            InitializeComponent();
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

        private void buttonAddLibrarian_Click(object sender, RoutedEventArgs e)
        {

            if(inputFirstName.Text.Trim() == string.Empty || inputLastName.Text.Trim() == string.Empty || inputPassword.Text.Trim() == string.Empty || inputUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("All fields are requried");
            }

        }
    }
}
