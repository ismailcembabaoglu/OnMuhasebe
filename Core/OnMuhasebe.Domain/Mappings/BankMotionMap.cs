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
    public class BankMotionMap : BaseModelMap, IEntityTypeConfiguration<BankMotion>
    {
        public void Configure(EntityTypeBuilder<BankMotion> builder)
        {
            builder.Property(bm => bm.VoucherCode).HasMaxLength(255);
            builder.Property(bm => bm.BankMotionType);
            builder.Property(bm => bm.BankId);
            builder.Property(bm => bm.CustomerId);
            builder.Property(bm => bm.Price).HasPrecision(18, 2);

        
        }
    }
}
