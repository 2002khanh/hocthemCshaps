using System;
using System.Collections.Generic;

namespace batitap18asp.Models
{
    public partial class Attribute
    {
        public int AttributeId { get; set; }
        public string? AttributeName { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? PriceSale { get; set; }
    }
}
