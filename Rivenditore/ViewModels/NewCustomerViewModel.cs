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



        private string _labelTitolo;

        public string LabelTitolo
        {
            get { return _labelTitolo; }
            set
            {
                _labelTitolo = value;
                NotifyPropretyChanged("LabelTitolo");
            }
        }

        private bool _salvaEnabled;

        public bool SalvaEnabled
        {
            get { return _salvaEnabled; }
            set { _salvaEnabled = value;
                NotifyPropretyChanged("SalvaEnabled");
            }
        }





        #endregion




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


        internal bool Salva()
        {
            if (LabelTitolo.Contains("Nuovo"))
            {
                /*
                if (!BaseViewModel.IsValid)
                {
                    MessageBox.Show("salvataggio non possibile");
                    return false;
                    
                }
                    
                else*/
                    CustomersController.Insert(SelectedCustomer);
            }
            else
                CustomersController.Modify(SelectedCustomer);

            return true;
                
        }

        internal void CheckSalva()
        {
            SalvaEnabled = IsValid;
        }
    }
}
