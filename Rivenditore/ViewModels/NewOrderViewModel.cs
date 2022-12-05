using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.Controllers;
using Rivenditore.Models;

namespace Rivenditore.ViewModels
{
    class NewOrderViewModel : BaseViewModel
    {
        private List<OrderDetail> _orderDetails;

        public List<OrderDetail> OrderDetails
        {
            get { return _orderDetails; }
            set { _orderDetails = value;
                NotifyPropretyChanged("OrderDetails");
            }
        }

        private List<Item> _listaItem;

        public List<Item> ListaItem
        {
            get { return _listaItem; }
            set { _listaItem = value;
                NotifyPropretyChanged("ListaItem");
            }
        }

        private List<Customer> _listaCustomer;

        public List<Customer> ListaCustomer
        {
            get { return _listaCustomer; }
            set { _listaCustomer =  value;
                NotifyPropretyChanged("ListaCustomer");
            }
        }

        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value;
                NotifyPropretyChanged("SelectedCustomer");
            }
        }



        public NewOrderViewModel()
        {
            OrderDetails = new List<OrderDetail>();
            Setup();

        }

        private async Task Setup()
        {
            ListaCustomer = await CustomersController.GetAll();
            ListaItem = await ItemsController.GetAll();
        }



    }
}
