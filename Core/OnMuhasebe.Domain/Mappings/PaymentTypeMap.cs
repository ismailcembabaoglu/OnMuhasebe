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
    public class PaymentTypeMap : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.PaymentTypeCode).HasMaxLength(50).IsRequired();
            builder.Property(pt => pt.PaymentTypeName).HasMaxLength(255).IsRequired();

            builder.HasMany(pt => pt.SafeBoxMotions).WithOne(sb => sb.PaymentType).HasForeignKey(sb => sb.PaymentTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
