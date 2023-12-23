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
    public class ProductMotionMap : BaseModelMap, IEntityTypeConfiguration<ProductMotion>
    {
        public void Configure(EntityTypeBuilder<ProductMotion> builder)
        {

            builder.Property(pm => pm.VoucherCode).HasMaxLength(255);
            builder.Property(pm => pm.MotionType);
            builder.Property(pm => pm.Quantity).HasPrecision(18, 3);
            builder.Property(pm => pm.Price).HasPrecision(18, 2);
            builder.Property(pm => pm.TotalAmount).HasPrecision(18, 2);
            builder.Property(pm => pm.DiscountRate).HasPrecision(18, 2);
            builder.Property(pm => pm.Date);

        }
    }
}
