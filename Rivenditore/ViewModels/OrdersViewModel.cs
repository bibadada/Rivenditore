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

        private Order _ordineSelezionato;

        public Order OrdineSelezionato
        {
            get { return _ordineSelezionato; }
            set { _ordineSelezionato = value;
                NotifyPropretyChanged("OrdineSelezionato");
            }
        }


        public OrdersViewModel()
        {
            Setup();
        }

        public async Task Setup()
        {
            this.ListaOrders = await OrdersController.GetAll();
        }

        internal void NuovoOrdine()
        {
            NewOrder newOrder = new NewOrder();
            newOrder.ShowDialog();
        }

        internal void Elimina()
        {
            this.ListaOrders = OrdersController.Delete(OrdineSelezionato, ListaOrders);
            Setup();
        }
    }
}
