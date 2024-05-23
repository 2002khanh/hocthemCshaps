using congnhan.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congnhan.Dbcontext
{
    public class NhanViencm : Microsoft.EntityFrameworkCore.DbContext
    {

        public virtual DbSet<NhanVien> NhanViens { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-4TLO7DBL\\SQLEXPRESS01;Initial Catalog=NhanVien;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True");
        }
       

    }
}
