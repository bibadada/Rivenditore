using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.ViewModels;

namespace Rivenditore.Models
{
    public partial class OrderDetail : BaseViewModel
    {
        public OrderDetail()
        {
            Quantity = 1;
        }

        public Item ItemBinding
        {
            get
            {
                return Item;
            }
            set
            {
                Item = value;
                SinglePriceBinding = value.Price ?? 0;
            }
        }
        public double SinglePriceBinding
        {
            get { return SinglePrice; }
            set
            {
                SinglePrice = value;
                NotifyPropretyChanged("SinglePriceBinding");
            }
        }
    }
}
    



