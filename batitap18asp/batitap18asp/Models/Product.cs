using System;
using System.Collections.Generic;

namespace batitap18asp.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string? ProductName { get; set; }
    }
}
