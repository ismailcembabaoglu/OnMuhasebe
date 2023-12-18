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
    public class ProductGroupMap : BaseModelMap, IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.Property(pg => pg.ProductGroupName).IsRequired();

            // Products ile ilişki
            builder.HasMany(pg => pg.Products).WithOne(p => p.ProductGroup).HasForeignKey(p => p.ProductGroupId).OnDelete(DeleteBehavior.Restrict);

            // ProductUnderGroups ile ilişki
            builder.HasMany(pg => pg.ProductUnderGroups).WithOne(pug => pug.ProductGroup).HasForeignKey(pug => pug.ProductGroupId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}

