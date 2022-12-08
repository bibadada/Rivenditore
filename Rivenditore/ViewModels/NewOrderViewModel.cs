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
        private Order ordineInModifica;
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

        private string _labelTitolo;

        public string LabelTitolo
        {
            get { return _labelTitolo; }
            set { _labelTitolo = value;
                NotifyPropretyChanged("LabelTitolo");
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

        private string _note;

        public string Note
        {
            get { return _note; }
            set { _note = value;
                NotifyPropretyChanged("Note");
            }
        }

        public NewOrderViewModel()
        {
            OrderDetails = new List<OrderDetail>();
            LabelTitolo = "Nuovo Ordine";
            Setup();

        }

        /*
        public NewOrderViewModel(Order order)
        {
            Setup().ContinueWith(l => { 
                OrderDetails = new List<OrderDetail>();
                OrderDetails = OrdersController.GetRowByOrder(order);
                LabelTitolo = "Modifica Ordine";
                SelectedCustomer = ListaCustomer.FirstOrDefault(c => c.Id == order.IdCustomer); //CustomersController.GetCustomerByOrder(order);
                Note = order.Notes;
            });
        }
        */
        
        public NewOrderViewModel(Order order)
        {
            ordineInModifica = new Order();
            ordineInModifica = order;
            Setup().ContinueWith(l => {
                OrderDetails = new List<OrderDetail>();
                OrderDetails = OrdersController.GetRowByOrder(order);
                foreach (var od in OrderDetails)
                {
                    od.Item = ListaItem.FirstOrDefault(q => q.Id == od.IdItem);
                }
                LabelTitolo = "Modifica Ordine";
                SelectedCustomer = ListaCustomer.FirstOrDefault(c => c.Id == order.IdCustomer); //CustomersController.GetCustomerByOrder(order);
                Note = order.Notes;
            });
        }
        

        private async Task Setup()
        {
            ListaCustomer = await CustomersController.GetAll();
            ListaItem = await ItemsController.GetAll();
        }
        internal void Salva()
        {
            if (LabelTitolo.Contains("Nuovo"))
                OrdersController.InsertOrder(SelectedCustomer.Id, Note, OrderDetails);
            else
                OrdersController.ModifyOrder(ordineInModifica, SelectedCustomer.Id, Note, OrderDetails);
        }



    }
}
