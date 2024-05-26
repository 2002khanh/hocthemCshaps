using System;
using System.Collections.Generic;

namespace baitap17.Models
{
    public partial class ProductImage
    {
        public int ImageId { get; set; }
        public int? SanPhamId { get; set; }
        public string? ImageUrl { get; set; }

        public virtual Product? SanPham { get; set; }
    }
}
