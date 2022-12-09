using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DateTime? StartProductionDate { get; set; }
        public DateTime? StopProductionDate { get; set; }
        public string Notes { get; set; }
        public List<OrderItemResponseDTO> OrderItems { get; set; }

    }
}
