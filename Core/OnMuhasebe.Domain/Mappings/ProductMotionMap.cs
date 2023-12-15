using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Mappings
{
    public class ProductMotionMap : IEntityTypeConfiguration<ProductMotion>
    {
        public void Configure(EntityTypeBuilder<ProductMotion> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.VoucherCode).HasMaxLength(255);
            builder.Property(pm => pm.MotionType).IsRequired();
            builder.Property(pm => pm.Quantity).HasPrecision(18, 3);
            builder.Property(pm => pm.Price).HasPrecision(18, 2);
            builder.Property(pm => pm.TotalAmount).HasPrecision(18, 2);
            builder.Property(pm => pm.DiscountRate).HasPrecision(18, 2);
            builder.Property(pm => pm.Date).IsRequired();

            builder.HasOne(pm => pm.Product).WithMany(p => p.ProductMotions).HasForeignKey(pm => pm.ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(pm => pm.Kdv).WithMany().HasForeignKey(pm => pm.KdvId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(pm => pm.Warehouse).WithMany(w => w.ProductMotions).HasForeignKey(pm => pm.WarehouseId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
