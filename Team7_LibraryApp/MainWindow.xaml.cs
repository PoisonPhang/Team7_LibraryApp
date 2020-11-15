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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LibraryDataRepo dataRepo { get; }

        public MainWindow()
        {
            InitializeComponent();
            dataRepo = new LibraryDataRepo();

        }

        /// <summary>
        /// To swap the screen
        /// </summary>
        /// <param name="element"></param>
        public void SwapScreen(UIElement element)
        {
            Container.Child = element;
        }

    }
}
