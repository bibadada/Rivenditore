using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.Models;
using Rivenditore.Controllers;

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


        #endregion

        public CustomersViewModel()
        {
            Setup();
        }

        private async Task Setup()
        {
            ListaCustomers = await CustomersController.GetAll();
        }
    }
}
