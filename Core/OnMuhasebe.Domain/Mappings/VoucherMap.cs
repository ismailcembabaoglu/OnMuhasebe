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
    public class VoucherMap : BaseModelMap, IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.Property(v => v.VoucherCode).HasMaxLength(50).IsRequired();
            builder.Property(v => v.VoucherType).IsRequired(); // Eğer VoucherType Enum ise tipini belirtin
            builder.Property(v => v.CustomerId).IsRequired();
            builder.Property(v => v.DocumentNo).HasMaxLength(100).IsRequired();
            builder.Property(v => v.DiscountRate).HasPrecision(18, 2).IsRequired();
            builder.Property(v => v.DiscountPrice).HasPrecision(18, 2).IsRequired();
            builder.Property(v => v.Owed).HasPrecision(18, 2).IsRequired();
            builder.Property(v => v.Debt).HasPrecision(18, 2).IsRequired();
            builder.Property(v => v.TotalPrice).HasPrecision(18, 2).IsRequired();

            builder.HasOne(v => v.Customer).WithMany(c => c.Vouchers).HasForeignKey(v => v.CustomerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(v => v.Bank).WithMany(b => b.Vouchers).HasForeignKey(v => v.BankId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
