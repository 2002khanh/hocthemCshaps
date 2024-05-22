using congnhan.Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congnhan.DTO
{
    public class CongViec
    {
     
            public int CongViecId { get; set; }
            public int NhanVienId { get; set; }
            public string? MoTa { get; set; }
            public DateTime NgayThucHien { get; set; }
            public int SoLuong { get; set; }

            public NhanVien NhanVien { get; set; }
       }  
}

