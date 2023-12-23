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
    public class DiscountMap : BaseModelMap, IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.Property(d => d.DiscountType);
            builder.Property(d => d.StartDate);
            builder.Property(d => d.EndDate);
            builder.Property(d => d.DiscountRatio).HasPrecision(18, 2);

        }
    }
}
