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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : UserControl
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = this.FindAncestor<MainWindow>();
            LibraryDataRepo dataRepo = mainWindow.dataRepo;

            if (textBoxUsername.Text == "" || !dataRepo.ValidateLogin(textBoxUsername.Text.Trim(), textBoxPassword.Password.Trim()))
            {
                labelWarning.Content = "Please enter a valid Username/Password";
            }
            else
            {
                Session.LibrarianId = textBoxUsername.Text.Trim();
                Session.Location = uxLocationDropDown.SelectedIndex;
                mainWindow.SwapScreen(new MainMenu());
            }


        }
    }
}
