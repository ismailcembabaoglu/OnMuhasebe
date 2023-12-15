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
    public class BankMotionMap : IEntityTypeConfiguration<BankMotion>
    {
        public void Configure(EntityTypeBuilder<BankMotion> builder)
        {
            builder.HasKey(bm => bm.Id);
            builder.Property(bm => bm.VoucherCode).HasMaxLength(255);
            builder.Property(bm => bm.BankMotionType).IsRequired();
            builder.Property(bm => bm.BankId).IsRequired();
            builder.Property(bm => bm.CustomerId).IsRequired();
            builder.Property(bm => bm.Price).HasPrecision(18, 2).IsRequired();

            builder.HasOne(bm => bm.Bank).WithMany(b => b.BankMotions).HasForeignKey(bm => bm.BankId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bm => bm.Customer).WithMany(c => c.BankMotions).HasForeignKey(bm => bm.CustomerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
