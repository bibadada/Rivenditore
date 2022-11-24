using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        internal void Salva()
        {
            CustomersController.Insert(SelectedCustomer);
        }

        #endregion
    }
}
