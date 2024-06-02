using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanphamdataAccessnetcore.DTO
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ShipingAddress { get; set; }
        public int TotalAmount { get; set; }
    }

    public class OrdersCreateRequestData
    {

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ShipingAddress { get; set; }

        public int TotalAmount { get; set; }
    }
}