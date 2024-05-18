namespace buoi_15_hocCshap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSach { get; set; }

        [Required]
        [StringLength(50)]
        public string TacGia { get; set; }

        public DateTime NXB { get; set; }
    }
}
