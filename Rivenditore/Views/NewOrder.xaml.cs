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
    /// Logica di interazione per NewOrder.xaml
    /// </summary>
    public partial class NewOrder : Window
    {
        public NewOrder()
        {
            InitializeComponent();
            NewOrderViewModel vm = new NewOrderViewModel();
            DataContext = vm;
        }
    }
}
