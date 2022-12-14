using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.ViewModels;

namespace Rivenditore.Models
{
    [MetadataTypeAttribute(typeof(OrderExtension))]
    public partial class Order : BaseViewModel
    {
        private DateTime? _deliveryDate;

        public DateTime? DeliveryDate
        {
            get {
                using(RivenditoreEntities context = new RivenditoreEntities())
                {
                    var d1 = this.DateOrederPlaced;
                    var d2 = context.OrderDetails.Where(w => w.IdOrder == Id).Max(m => m.Item.LeadTime);

                    if (d1 != null && d2 != null)
                    {
                        var v = (DateTime)d1;
                        var v2 = (double)d2;

                        return v.AddDays(v2);
                    }
                return null;
                }
                
            }
        }

        private double _totalImport;

        public double TotalImport
        {
            get
            {

                using (RivenditoreEntities context = new RivenditoreEntities())
                {
                    _totalImport = context.OrderDetails.Where(od => od.IdOrder == Id).Sum(od => od.SinglePrice*od.Quantity);
                    return _totalImport;
                }

            }
        }

    }

    class OrderExtension
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public int IdOrderStates { get; set; }
        public string IdApi { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<System.DateTime> DateOrederPlaced { get; set; }
        public string Notes { get; set; }
    }

}
