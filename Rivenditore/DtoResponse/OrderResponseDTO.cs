using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rivenditore.DtoRequest;

namespace Rivenditore.DtoResponse
{
    class OrderResponseDTO
    {
        public string Id { get; set; }
        public string ResellerId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStateId { get; set; }
        public DateTime SendDate { get; set; }
        public object StartProductionDate { get; set; }
        public object StopProductionDate { get; set; }
        public object Notes { get; set; }
        //public List<OrderItemDTO> OrderItems { get; set; }

    }
}
