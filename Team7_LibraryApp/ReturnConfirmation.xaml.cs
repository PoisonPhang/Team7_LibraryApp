﻿using System;
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
    /// Interaction logic for ReturnConfirmation.xaml
    /// </summary>
    public partial class ReturnConfirmation : UserControl
    {
        public ReturnConfirmation(BookReturn book)
        {
            InitializeComponent();

            textBlock.Text = book.Title + "\n\nSuccessfully Returned.";

        }

        private void buttonOkay_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = this.FindAncestor<MainWindow>();
            mainWindow.SwapScreen(new MainMenu());
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
    }
}
