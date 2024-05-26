using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace baitap17.Models
{
    public partial class SanPhamDbContext : DbContext
    {
        public SanPhamDbContext()
        {
        }

        public SanPhamDbContext(DbContextOptions<SanPhamDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;
        public virtual DbSet<ProductVariant> ProductVariants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(" Data Source=LAPTOP-4TLO7DBL\\SQLEXPRESS01;Initial Catalog=SanPhamDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.SanPhamId)
                    .HasName("PK__Product__05180FD41EBCABC5");

                entity.ToTable("Product");

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.ProductType).HasMaxLength(255);
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(e => e.ImageId)
                    .HasName("PK__ProductI__7516F70C7CABE33D");

                entity.ToTable("ProductImage");

                entity.Property(e => e.ImageUrl).HasMaxLength(255);

                entity.HasOne(d => d.SanPham)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.SanPhamId)
                    .HasConstraintName("FK__ProductIm__SanPh__29572725");
            });

            modelBuilder.Entity<ProductVariant>(entity =>
            {
                entity.HasKey(e => e.VariantId)
                    .HasName("PK__ProductV__0EA23384FF0D95C3");

                entity.ToTable("ProductVariant");

                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Cpu)
                    .HasMaxLength(50)
                    .HasColumnName("CPU");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Ram)
                    .HasMaxLength(50)
                    .HasColumnName("RAM");

                entity.Property(e => e.ScreenSize).HasMaxLength(50);

                entity.Property(e => e.Storage).HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVariants)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductVa__Produ__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
