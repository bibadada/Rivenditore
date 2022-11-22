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

namespace Rivenditore.Views
{
    /// <summary>
    /// Logica di interazione per MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private MainMenuViewModel vm;
        public MainMenu()
        {
            InitializeComponent();
            vm = new MainMenuViewModel();
            this.DataContext = vm;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Customers());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Orders());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Items());
        }
    }
}
