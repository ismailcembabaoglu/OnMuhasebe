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
    public class ProducUnderGroupMap : BaseModelMap, IEntityTypeConfiguration<ProductUnderGroup>
    {

        public void Configure(EntityTypeBuilder<ProductUnderGroup> builder)
        {
            builder.Property(pug => pug.ProductUnderGroupName);

            // ProductGroup ile ilişki
            builder.HasOne(pug => pug.ProductGroup).WithMany(pg => pg.ProductUnderGroups).HasForeignKey(pug => pug.ProductGroupId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
