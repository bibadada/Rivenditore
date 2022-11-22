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
    /// Logica di interazione per Customers.xaml
    /// </summary>
    public partial class Customers : Page
    {
        CustomersViewModel vm;
        public Customers()
        {
            InitializeComponent();
            vm = new CustomersViewModel();
            this.DataContext = vm;
        }
    }
}
