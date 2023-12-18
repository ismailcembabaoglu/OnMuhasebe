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
    public class BankMap : BaseModelMap, IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.Property(b => b.AccountCode).HasMaxLength(50).IsRequired();
            builder.Property(b => b.AccountName).HasMaxLength(100).IsRequired();
            builder.Property(b => b.BankName).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Branch).HasMaxLength(100);
            builder.Property(b => b.IbanNo).HasMaxLength(26);
            builder.Property(b => b.AccountNo).HasMaxLength(20).IsRequired();
            builder.Property(b => b.AuthName).HasMaxLength(100);
            builder.Property(b => b.AuthPhone).HasMaxLength(20);

            builder.HasMany(b => b.BankMotions).WithOne(bm => bm.Bank).HasForeignKey(bm => bm.BankId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(b => b.Vouchers).WithOne(v => v.Bank).HasForeignKey(v => v.BankId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
