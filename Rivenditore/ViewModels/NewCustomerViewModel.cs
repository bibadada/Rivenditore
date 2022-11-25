using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Rivenditore.Controllers;
using Rivenditore.Models;

namespace Rivenditore.ViewModels
{
    class NewCustomerViewModel : BaseViewModel
    {
        #region BINDING PROPERTY

        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value;
                NotifyPropretyChanged("SelectedCustomer");
            }
        }

        public NewCustomerViewModel()
        {
            SelectedCustomer = new Customer();
        }

        public NewCustomerViewModel(Customer c)
        {
            SelectedCustomer = new Customer();
            SelectedCustomer = c;
        }

        internal void Salva()
        {
            if (SelectedCustomer.Name == null && SelectedCustomer.Surname == null)
                MessageBox.Show("i campi Nome e Cognome devono essere compitlati");
            else
                CustomersController.Insert(SelectedCustomer);
        }

        #endregion
    }
}
