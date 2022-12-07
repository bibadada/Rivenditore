﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rivenditore.Models
{
    public partial class Order
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
}
