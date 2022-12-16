using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                NotifyPropretyChanged("SalvaEnabled");
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
                NotifyPropretyChanged("SalvaEnabled");
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

        private bool _isReadOnly;

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set {_isReadOnly = value;
                IsEnabledCombo = !value;
                VisibilitySalva = value ? "Hidden" : "Visible";
                AnnullaOrChiudi = value ? "Chiudi" : "Annulla";
                NotifyPropretyChanged("IsReadOnly");
            }
        }

        private bool _isEnabledCombo;

        public bool IsEnabledCombo
        {
            get { return _isEnabledCombo; }
            set { _isEnabledCombo = value;
                NotifyPropretyChanged("IsEnabledCombo");
            }
        }

        private string _visibilitySalva;

        public string VisibilitySalva
        {
            get { return _visibilitySalva; }
            set { _visibilitySalva = value;
                NotifyPropretyChanged("VisibilitySalva");
            }
        }

        private string _annullaOrChiudi;

        public string AnnullaOrChiudi
        {
            get { return _annullaOrChiudi; }
            set { _annullaOrChiudi = value;
                NotifyPropretyChanged("AnnullaOrChiudi");
            }
        }

        private bool _salvaEnabled;

        public bool SalvaEnabled
        {
            get { if (SelectedCustomer != null && OrderDetails.Count > 0)
                    _salvaEnabled = true;
                return _salvaEnabled; }
            set { _salvaEnabled = value;
                NotifyPropretyChanged("SalvaEnabled");
            }
        }

        internal void NuovoElementoInGriglia()
        {
            NotifyPropretyChanged("SalvaEnabled");
        }


        public NewOrderViewModel()
        {
            OrderDetails = new List<OrderDetail>();
            LabelTitolo = "Nuovo Ordine";
            IsReadOnly = false;
            //SalvaEnabled = false;
            Setup();

        }

        
        public NewOrderViewModel(Order order)
        {
            ordineInModifica = new Order();
            ordineInModifica = order;
            IsReadOnly = false;
            LabelTitolo = "Modifica Ordine";
            Setup().ContinueWith(l => {
                OrderDetails = new List<OrderDetail>();
                OrderDetails = OrdersController.GetRowByOrder(order);
                foreach (var od in OrderDetails)
                {
                    od.Item = ListaItem.FirstOrDefault(q => q.Id == od.IdItem);
                }
                SelectedCustomer = ListaCustomer.FirstOrDefault(c => c.Id == order.IdCustomer); //CustomersController.GetCustomerByOrder(order);
                Note = order.Notes;
            });
        }

        public NewOrderViewModel(Order order, string label) : this(order)
        {
            LabelTitolo = label;
            IsReadOnly = true;
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
            {
                
                OrdersController.ModifyOrder(ordineInModifica, SelectedCustomer.Id, Note, OrderDetails);

            }
                
        }



    }
}
