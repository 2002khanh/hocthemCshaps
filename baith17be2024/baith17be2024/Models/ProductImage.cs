namespace baith17be2024.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductImage")]
    public partial class ProductImage
    {
        [Key]
        public int ImageId { get; set; }

        public int? SanPhamId { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        public virtual Product Product { get; set; }
    }
}
