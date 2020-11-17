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
    /// Interaction logic for AddBookTwo.xaml
    /// </summary>
    public partial class AddBookTwo : UserControl
    {
        public AddBookTwo(Book book, String isbn) 
        {
            InitializeComponent();

            populateScreen(book, isbn);

        }

        private void populateScreen(Book book, String isbn)
        {


            if (book != null)
            {

                inputTitle.Text = book.Title;
                inputPublisher.Text = book.Publisher;
                inputISBN.Text = book.ISBN;
                inputYear.Text = book.Year.ToString();
                inputGenre.Text = book.Genre;
                //
                //
                inputComboBox.SelectedIndex = Session.Location;

                inputTitle.IsEnabled = false;
                inputPublisher.IsEnabled = false;
                inputISBN.IsEnabled = false;
                inputYear.IsEnabled = false;
                inputGenre.IsEnabled = false;
                inputAuthorFirstName.IsEnabled = false;
                inputAuthorLastName.IsEnabled = false;





            } else
            {

                inputISBN.Text = isbn;
                inputISBN.IsEnabled = false;

                inputComboBox.SelectedIndex = Session.Location - 1;

            }

        }


        #region Menu Buttons

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

        #endregion



    }
}
