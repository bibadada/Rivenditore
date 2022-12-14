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
    /// Logica di interazione per Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        private OrdersViewModel vm;
        public Orders()
        {
            InitializeComponent();
            vm = new OrdersViewModel();
            this.DataContext = vm;
        }

        private void Elimina_Click(object sender, RoutedEventArgs e)
        {
            vm.Elimina();
        }

        private void NuovoOrdine_Click(object sender, RoutedEventArgs e)
        {
            vm.NuovoOrdine();
        }

        private void Conferma_Click(object sender, RoutedEventArgs e)
        {
            vm.ConfermaOrdine();
        }

        private void Modifica_Click(object sender, RoutedEventArgs e)
        {
            vm.ModificaOrdine();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            vm.RicaricaStati();
        }

        private void OrdiniDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            vm.VisualizzaOrdine();
        }
    }
}
