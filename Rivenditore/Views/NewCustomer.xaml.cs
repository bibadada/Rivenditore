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
using Rivenditore.ViewModels;

namespace Rivenditore.Views
{
    /// <summary>
    /// Logica di interazione per NewCustomer.xaml
    /// </summary>
    public partial class NewCustomer : Window
    {
        private NewCustomerViewModel vm;
        public NewCustomer()
        {
            InitializeComponent();
            vm = new NewCustomerViewModel();
            DataContext = vm;
        }

        private void Salva_Click(object sender, RoutedEventArgs e)
        {
            vm.Salva();
            this.Close();
        }
    }
}
