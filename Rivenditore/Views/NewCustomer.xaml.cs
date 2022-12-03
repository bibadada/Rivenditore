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
using Rivenditore.Models;
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

        public NewCustomer(Customer c)
        {
            InitializeComponent();
            vm = new NewCustomerViewModel(c);
            DataContext = vm;
        }

        private void Salva_Click(object sender, RoutedEventArgs e)
        {
            if(vm.Salva())
                this.Close();

        }

        private void Annulla_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            vm.CheckSalva();
        }
    }
}
