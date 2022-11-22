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
using Rivenditore.ViewModels;
using Rivenditore.Views;

namespace Rivenditore
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new MainWindowViewModel();
            this.DataContext = vm;
        }

        private void MenuItemClienti_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.Navigate(new Customers());
        }

        private void MenuItemOrdini_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.Navigate(new Orders());
        }

        private void MenuItemArticoli_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.Navigate(new Items());
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.Navigate(new MainMenu());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void MenuItem_Click_About(object sender, RoutedEventArgs e)
        {
            //TODO MESSAGEBOX
        }
    }
}
