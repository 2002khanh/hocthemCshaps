using System;
using System.Collections.Generic;

namespace baitap17.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductImages = new HashSet<ProductImage>();
            ProductVariants = new HashSet<ProductVariant>();
        }

        public int SanPhamId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
