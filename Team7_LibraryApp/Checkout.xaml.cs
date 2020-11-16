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

        public Checkout()
        {
            InitializeComponent();
            //LibraryDataRepo = mainWindow.dataRepo;
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
            mainWindow = this.FindAncestor<MainWindow>();
            LibraryDataRepo repo = mainWindow.dataRepo;

            repo.CheckoutBook(Int32.Parse(uxBookId.Text), Int32.Parse(uxUserId.Text), Location.loc, LibrarianId.Id, DateTime.Today.ToString(), DateTime.Today.AddDays(14).ToString());

            MessageBox.Show("Book checked out");

            mainWindow.SwapScreen(new MainMenu());


        }

        private void BookSelected(object sender, SelectionChangedEventArgs e)
        {
            BookCopy book = (BookCopy)listViewReportOne.SelectedItem;
            uxBookId.Text = book.BookId.ToString();
        }
    }
}
