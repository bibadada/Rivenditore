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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Rivenditore.Models;
using Rivenditore.ViewModels;

namespace Rivenditore.Views
{
    /// <summary>
    /// Logica di interazione per NewOrder.xaml
    /// </summary>
    public partial class NewOrder : MetroWindow
    {
        private NewOrderViewModel vm;
        public NewOrder()
        {
            InitializeComponent();
            vm = new NewOrderViewModel();
            DataContext = vm;
        }
        public NewOrder(Order order)
        {
            InitializeComponent();
            vm = new NewOrderViewModel(order);
            DataContext = vm;
        }

        public NewOrder(Order order, string label)
        {
            InitializeComponent();
            vm = new NewOrderViewModel(order, label);
            DataContext = vm;
        }

        private void Salva_Click(object sender, RoutedEventArgs e)
        {
            vm.Salva();
            this.Close();

        }

        private void Annulla_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            vm.NuovoElementoInGriglia();
        }
    }
}
