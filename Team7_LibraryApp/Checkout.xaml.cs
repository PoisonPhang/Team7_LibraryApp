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
    /// Interaction logic for Checkout.xaml
    /// </summary>
    public partial class Checkout : UserControl
    {
        private MainWindow mainWindow;

        public Checkout(MainWindow m)
        {
            InitializeComponent();
            listViewReportOne.ItemsSource = m.dataRepo.GetBookCopiesByTitle(searchStringTextBox.Text);
        }

        private void buttonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            mainWindow = this.FindAncestor<MainWindow>();
            mainWindow.SwapScreen(new MainMenu());
        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = this.FindAncestor<MainWindow>();
            mainWindow.SwapScreen(new LogIn());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedFuntion = (ComboBoxItem)uxSearchFunction.SelectedItem;
            mainWindow = this.FindAncestor<MainWindow>();
            LibraryDataRepo repo = mainWindow.dataRepo;

            if (selectedFuntion.Content.ToString() == "Title")
            {
                listViewReportOne.ItemsSource = repo.GetBookCopiesByTitle(searchStringTextBox.Text);
            }
            else if (selectedFuntion.Content.ToString() == "Author")
            {
                listViewReportOne.ItemsSource = repo.GetBookCopiesByAuthor(searchStringTextBox.Text);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if(uxUserId.Text != String.Empty && uxBookId.Text != String.Empty && !String.IsNullOrWhiteSpace(uxUserId.Text) && !String.IsNullOrWhiteSpace(uxUserId.Text))
            {
                try
                {
                    mainWindow = this.FindAncestor<MainWindow>();
                    LibraryDataRepo repo = mainWindow.dataRepo;

                    BookCheckout book = repo.CheckoutBook(Int32.Parse(uxBookId.Text), Int32.Parse(uxUserId.Text), Session.Location, Session.LibrarianId, DateTime.Today.ToString(), DateTime.Today.AddDays(14).ToString());

                    String confirmation = book.Title + " Checked Out To " + book.UserFirstName + " " + book.UserLastName + "\n\nDate Due: " + DateTime.Today.AddDays(14).ToString("yyyy-MM-dd");

                    mainWindow.SwapScreen(new MessageWindow(confirmation));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }




        }

        private void BookSelected(object sender, SelectionChangedEventArgs e)
        {
            BookCopy book = (BookCopy)listViewReportOne.SelectedItem;

            if(book != null)
            {
                uxBookId.Text = book.BookId.ToString();

            }
        }
    }
}
