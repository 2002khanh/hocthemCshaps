using System;
using System.Collections.Generic;

namespace baitap17.Models
{
    public partial class ProductVariant
    {
        public int VariantId { get; set; }
        public int? ProductId { get; set; }
        public string? ScreenSize { get; set; }
        public string? Ram { get; set; }
        public string? Storage { get; set; }
        public string? Cpu { get; set; }
        public string? Color { get; set; }
        public decimal? Price { get; set; }

        public virtual Product? Product { get; set; }
    }
}
