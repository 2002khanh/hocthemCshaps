using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using baithuchanhnetcore16.Models;

namespace baithuchanhnetcore16.Data
{
    public class baithuchanhnetcore16Context : DbContext
    {
        public baithuchanhnetcore16Context (DbContextOptions<baithuchanhnetcore16Context> options)
            : base(options)
        {
        }

        public DbSet<baithuchanhnetcore16.Models.Book> Book { get; set; } = default!;
    }
}
