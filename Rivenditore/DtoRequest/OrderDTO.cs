using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rivenditore.DtoRequest
{
    class OrderDTO
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Notes { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
