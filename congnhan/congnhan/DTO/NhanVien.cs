using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congnhan.DTO
{
  public class NhanVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NhanVienId { get; set; }
        [MaxLength(100)]

        public string?  HoTen  { get; set; }
        [MaxLength(100)]

        public string? ChuyenMay { get; set; }
        public int SoLuong { get; set; }
        
    }
}
