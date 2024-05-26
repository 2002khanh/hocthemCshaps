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
        
        public int NhanVienId { get; set; }
     

        public string?  HoTen  { get; set; }
   

        public string? ChuyenMay { get; set; }
        public int SoLuong { get; set; }
        
    }
}
