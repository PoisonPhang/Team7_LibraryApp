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
using Team7_LibraryApp.Data;

namespace Team7_LibraryApp
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : UserControl
    {
        public AddUser()
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

        private void buttonAddUser_Click(object sender, RoutedEventArgs e)
        {

            if(inputFirstName.Text.Trim() == string.Empty || inputLastName.Text.Trim() == string.Empty || inputEmail.Text.Trim() == string.Empty || inputStreet.Text.Trim() == string.Empty 
                || inputUnit.Text.Trim() == string.Empty || inputZipCode.Text.Trim() == string.Empty || inputCityName.Text.Trim() == string.Empty || inputStateCode.Text.Trim() == string.Empty)
            {

                MessageBox.Show("All Fields Are Requried");

            }
            else
            {

                var mainWindow = this.FindAncestor<MainWindow>();

                try
                {


                    int zipCode;

                    bool success = Int32.TryParse(inputZipCode.Text.Trim(), out zipCode);

                    if (success)
                    {
                        LibraryDataRepo repo = mainWindow.dataRepo;
                        User u = repo.AddUser(inputFirstName.Text.Trim(), inputLastName.Text.Trim(), inputEmail.Text.Trim(), inputStreet.Text.Trim(), inputUnit.Text.Trim(), zipCode, inputCityName.Text.Trim(), inputStateCode.Text.Trim());
                            
                        string confirmation = u.FirstName + " added with a User Id of: " + u.UserId.ToString();

                        mainWindow.SwapScreen(new MessageWindow(confirmation));


                    }
                    else
                    {
                        MessageBox.Show("Zipcode Must Be A Number");
                    }



                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }


            }

        }
    }
}
