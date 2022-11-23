using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.Models;
using Rivenditore.Controllers;

namespace Rivenditore.ViewModels
{
    class OrdersViewModel : BaseViewModel
    {
        private List<Order> _listaOrders;

        public List<Order> ListaOrders
        {
            get { return _listaOrders; }
            set { _listaOrders = value;
                NotifyPropretyChanged("ListaOrders");
            }
        }

        public OrdersViewModel()
        {
          
        }

        public async Task Setup()
        {
            this.ListaOrders = await OrdersController.GetAll();
        }

    }
}
