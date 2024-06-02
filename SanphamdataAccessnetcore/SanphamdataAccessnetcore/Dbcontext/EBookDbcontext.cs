using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanphamdataAccessnetcore.Dbcontext
{
    public class EBookDbcontext:Microsoft.EntityFrameworkCore.DbContext
    {
        
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-4TLO7DBL\\SQLEXPRESS01;Initial Catalog=SanPhamDBg;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True");
            }
            public virtual DbSet<Book> book { get; set; }

            public virtual DbSet<Product> product { get; set; }
            public virtual DbSet<ProductAttribute> productAttribute { get; set; }
            public virtual DbSet<Orders> order { get; set; }
        }
    }

