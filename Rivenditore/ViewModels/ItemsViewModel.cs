using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.Controllers;
using Rivenditore.Models;

namespace Rivenditore.ViewModels
{
    class ItemsViewModel : BaseViewModel
    {

        #region BINDING PROPERTIES

        private List<Item> _listaItems;

        public List<Item> ListaItems
        {
            get { return _listaItems; }
            set { _listaItems = value;
                NotifyPropretyChanged("ListaItems");
            }
        }

        #endregion

        public ItemsViewModel()
        {
            this.Setup();
        }

        public async Task Setup()
        {
            this.ListaItems = await ItemsController.GetAll();
        }

    }
}
