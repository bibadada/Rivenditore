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

        private List<int> _listaItem;

        public List<int> ListaItem
        {
            get { return _listaItem; }
            set { _listaItem = value;
                NotifyPropretyChanged("ListaItem");
            }
        }

        private List<int> _listaCustomer;

        public List<int> ListaCustomer
        {
            get { return _listaCustomer; }
            set { _listaCustomer =  value;
                NotifyPropretyChanged("ListaCustomer");
            }
        }


        public NewOrderViewModel()
        {
            OrderDetails = new List<OrderDetail>();
            Setup();

        }

        private async Task Setup()
        {
            //ListaCustomer = await CustomersController.GetAllIds();
            //ListaItem = await ItemsController.GetAllIds();
        }



    }
}
