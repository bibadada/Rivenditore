using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rivenditore.DtoResponse
{
    class OrderItemResponseDTO
    {

        public string OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double UnitaryPrice { get; set; }

    }
}
