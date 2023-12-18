using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnMuhasebe.Domain.Models;
using OnMuhasebe.Domain.Mappings.BaseModelMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Mappings
{
    public class ProductMap : BaseModelMap, IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.IsActive);
            builder.Property(p => p.ProductNumber);
            builder.Property(p => p.Barcode);
            builder.Property(p => p.Brand);
            builder.Property(p => p.Model);
            builder.Property(p => p.GuaranteePeriod);
            builder.Property(p => p.Producer);
            builder.Property(p => p.Photo);

            // ProductGroup ile ilişki
            builder.HasOne(p => p.ProductGroup).WithMany(pg => pg.Products).HasForeignKey(p => p.ProductGroupId).OnDelete(DeleteBehavior.Restrict);

            // SpecialCodes ile ilişki
            builder.HasMany(p => p.SpecialCodes).WithOne(sc => sc.Product).HasForeignKey(sc => sc.ProductId).OnDelete(DeleteBehavior.Restrict);

            // Prices ile ilişki
            builder.HasMany(p => p.Prices).WithOne(pr => pr.Product).HasForeignKey(pr => pr.ProductId).OnDelete(DeleteBehavior.Restrict);

            // ProductMotions ile ilişki
            builder.HasMany(p => p.ProductMotions).WithOne(pm => pm.Product).HasForeignKey(pm => pm.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
