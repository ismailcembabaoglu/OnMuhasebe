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
    public class SafeBoxMotionMap : BaseModelMap, IEntityTypeConfiguration<SafeBoxMotion>
    {
        public void Configure(EntityTypeBuilder<SafeBoxMotion> builder)
        {
            builder.Property(sb => sb.VoucherCode);
            builder.Property(sb => sb.SafeBoxMotionType);
            builder.Property(sb => sb.Price).HasPrecision(18, 2);

            // SafeBox ile ilişki
            builder.HasOne(sb => sb.SafeBox).WithMany(s => s.SafeBoxMotions).HasForeignKey(sb => sb.SafeBoxId).OnDelete(DeleteBehavior.Restrict);

            // PaymentType ile ilişki
            builder.HasOne(sb => sb.PaymentType).WithMany(pt => pt.SafeBoxMotions).HasForeignKey(sb => sb.PaymentTypeId).OnDelete(DeleteBehavior.Restrict);

           
        }
    }
}
