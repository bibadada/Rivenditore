using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.Models;
using Rivenditore.Controllers;
using Rivenditore.Views;

namespace Rivenditore.ViewModels
{
    class CustomersViewModel : BaseViewModel
    {
        #region BindingSource

        private List<Customer> _listaCustomers;

        public List<Customer> ListaCustomers
        {
            get { return _listaCustomers; }
            set{ _listaCustomers = value;
                NotifyPropretyChanged("ListaCustomers");
            }
        }

        private Customer _customerSelezionato;

        public Customer CustomerSelezionato
        {
            get { return _customerSelezionato; }
            set { _customerSelezionato = value;
                NotifyPropretyChanged("CustomerSelezionato");
            }
        }      

        #endregion

        public CustomersViewModel()
        {
            Setup();
        }

        private async Task Setup()
        {
            ListaCustomers = await CustomersController.GetAll();
            

        }

        internal void NuovoCliente()
        {
            NewCustomer newCustomer = new NewCustomer();
            newCustomer.ShowDialog();
            Setup();
        }

        internal void ModificaCliente()
        {
            NewCustomer newCustomer = new NewCustomer(this.CustomerSelezionato);
            newCustomer.ShowDialog();
            Setup();
        }
    }
}
