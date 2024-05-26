namespace baith17be2024.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductVariant")]
    public partial class ProductVariant
    {
        [Key]
        public int VariantId { get; set; }

        public int? ProductId { get; set; }

        [StringLength(50)]
        public string ScreenSize { get; set; }

        [StringLength(50)]
        public string RAM { get; set; }

        [StringLength(50)]
        public string Storage { get; set; }

        [StringLength(50)]
        public string CPU { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public decimal? Price { get; set; }

        public virtual Product Product { get; set; }
    }
}
