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
        #endregion

        private string _labelTitolo;

        public string LabelTitolo
        {
            get { return _labelTitolo; }
            set { _labelTitolo = value;
                NotifyPropretyChanged("LabelTitolo");
            }
        }


        public NewCustomerViewModel()
        {
            SelectedCustomer = new Customer();
            LabelTitolo = "Nuovo Cliente";
        }

        public NewCustomerViewModel(Customer c)
        {
            SelectedCustomer = new Customer();
            SelectedCustomer = c;
            LabelTitolo = "Modifica Cliente " + c.Id;

        }

        internal void Salva()
        {
            if (LabelTitolo.Contains("Nuovo"))
                CustomersController.Insert(SelectedCustomer);
            else
                CustomersController.Modify(SelectedCustomer);
        }

    }
}
