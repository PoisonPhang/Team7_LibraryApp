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


            if (book != null) {

                inputTitle.Text = book.Title;
                inputPublisher.Text = book.Publisher;
                inputISBN.Text = book.ISBN;
                inputYear.Text = book.Year.ToString();
                inputGenre.SelectedIndex = book.GenreCode - 2; 

                
                inputAuthorFirstName.Text = book.AuthorFirstName;
                inputAuthorLastName.Text = book.AuthorLastName;
               
                inputLocation.SelectedIndex = Session.Location - 1;

                inputTitle.IsEnabled = false;
                inputPublisher.IsEnabled = false;
                inputISBN.IsEnabled = false;
                inputYear.IsEnabled = false;
                inputGenre.IsEnabled = false;

                inputAuthorFirstName.IsEnabled = false;
                inputAuthorLastName.IsEnabled = false;

            } 
            else {
                inputISBN.Text = isbn;
                inputISBN.IsEnabled = false;

                inputGenre.SelectedIndex = 0;

                inputLocation.SelectedIndex = Session.Location - 1;

            }
        }


        private string getGenreString(int id)
        {
            if(id == 1)
            {
                return "All Genres";
            }
            else if(id == 2)
            {
                return "Fiction";
            }
            else if (id == 3)
            {
                return "NonFiction";
            }
            else if (id == 4)
            {
                return "Mystery";
            }
            else if (id == 5)
            {
                return "Romance";
            }
            else if (id == 6)
            {
                return "History";
            }
            else if (id == 7)
            {
                return "Biography";
            }
            else if (id == 8)
            {
                return "Children";
            }
            else if (id == 9)
            {
                return "Drama";
            }
            else if (id == 10)
            {
                return "Science Fiction";
            }
            else if (id == 11)
            {
                return "True Crime";
            }
            else if (id == 12)
            {
                return "Young Adult";
            }
            else
            {
                return "";
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

        private void buttonAddBook_Click(object sender, RoutedEventArgs e)
        {
            if(inputTitle.Text.Trim() == string.Empty || inputPublisher.Text.Trim() == string.Empty || inputISBN.Text.Trim() == string.Empty || inputYear.Text.Trim() == string.Empty
                || inputAuthorFirstName.Text.Trim() == string.Empty || inputAuthorLastName.Text.Trim() == string.Empty|| inputNumberOfCopies.Text.Trim() == string.Empty)
            {
                MessageBox.Show("All Fields are Required");
            }
            else
            {

                try
                {

                    int GenreCode = inputGenre.SelectedIndex + 2;

                    int Year;
                    bool yearSuccess = Int32.TryParse(inputYear.Text.Trim(), out Year);
                    if (!yearSuccess) { MessageBox.Show("Year must be a number."); }


                    int numberCopies;
                    bool numberSuccess = Int32.TryParse(inputNumberOfCopies.Text.Trim(), out numberCopies);
                    if (!numberSuccess){MessageBox.Show("Number of Copies must be a number");}



                    if (numberSuccess && numberSuccess)
                    {

                        var mainWindow = this.FindAncestor<MainWindow>();

                        mainWindow.dataRepo.AddBook(inputISBN.Text, inputTitle.Text, GenreCode, inputPublisher.Text, Year, inputAuthorFirstName.Text, inputAuthorLastName.Text);

                        for(int i = 0; i < numberCopies; i++)
                        {
                            mainWindow.dataRepo.AddBookCopy(inputISBN.Text, inputLocation.SelectedIndex + 1);
                        }

                        string confirmation = inputTitle.Text + " was added successfully!";
                        mainWindow.SwapScreen(new MessageWindow(confirmation));

                    }

                } 
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

            }
        }
    }
}
