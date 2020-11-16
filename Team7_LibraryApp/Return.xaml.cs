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
    /// Interaction logic for Return.xaml
    /// </summary>
    public partial class Return : UserControl
    {
        public Return(MainWindow m)
        {
            InitializeComponent();

            listViewReportOne.ItemsSource = m.dataRepo.GetAllActiveCheckouts();
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

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = this.FindAncestor<MainWindow>();
            LibraryDataRepo repo = mainWindow.dataRepo;


            if(uxSearchFunction.SelectedItem == null)
            {

            }

            else if (uxSearchFunction.SelectedItem.ToString() == "Book ID")
            {
                int number;

                bool result = Int32.TryParse(inputSearch.Text, out number);

                if (result)
                {
                    listViewReportOne.ItemsSource = repo.GetBookCheckoutsByBookId(number);
                }
                

            }
            else if (uxSearchFunction.SelectedItem.ToString() == "User's Name")
            {
                listViewReportOne.ItemsSource = repo.GetBookCheckoutsByUsersName(inputSearch.Text);
            }


        }

        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = this.FindAncestor<MainWindow>();
            LibraryDataRepo repo = mainWindow.dataRepo;

            int ID;

            bool result = Int32.TryParse(inputBookId.Text, out ID);

            if (result)
            {
                repo.ReturnBook(ID, Location.loc);

                MessageBox.Show("Book Returned");

                mainWindow.SwapScreen(new MainMenu());

            }

        }

        private void listViewReportOne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookCheckout book = (BookCheckout)listViewReportOne.SelectedItem;
            inputBookId.Text = book.BookId.ToString();
        }
    }
}
