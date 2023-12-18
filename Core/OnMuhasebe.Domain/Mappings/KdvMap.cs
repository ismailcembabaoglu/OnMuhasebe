
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
    public class KdvMap: BaseModelMap, IEntityTypeConfiguration<Kdv>
    {
        public void Configure(EntityTypeBuilder<Kdv> builder)
        {
            builder.Property(k => k.KdvName).HasMaxLength(255).IsRequired();
            builder.Property(k => k.KdvRatio).HasPrecision(18, 2).IsRequired();

            builder.HasMany(k => k.Prices).WithOne(p => p.Kdv).HasForeignKey(p => p.KdvId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
