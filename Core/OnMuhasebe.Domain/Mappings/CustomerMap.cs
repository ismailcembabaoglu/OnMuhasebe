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
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.CustomerType).HasMaxLength(50).IsRequired();
            builder.Property(c => c.CustomerName).HasMaxLength(100).IsRequired();
            builder.Property(c => c.CustomerCode).HasMaxLength(20).IsRequired();
            builder.Property(c => c.AuthName).HasMaxLength(100);
            builder.Property(c => c.InvoiceTitle).HasMaxLength(100);
            builder.Property(c => c.PersonPhoneNumber).HasMaxLength(20);
            builder.Property(c => c.Phone).HasMaxLength(20);
            builder.Property(c => c.Fax).HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.Property(c => c.Website).HasMaxLength(100);
            builder.Property(c => c.Country).HasMaxLength(50);
            builder.Property(c => c.City).HasMaxLength(50);
            builder.Property(c => c.District).HasMaxLength(50);
            builder.Property(c => c.TaxOffice).HasMaxLength(50);
            builder.Property(c => c.TaxNumber).HasMaxLength(20);
            builder.Property(c => c.DiscountRatio).HasPrecision(18, 2);
            builder.Property(c => c.RiskLimit).HasMaxLength(50);

            builder.HasMany(c => c.BankMotions).WithOne(bm => bm.Customer).HasForeignKey(bm => bm.CustomerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Vouchers).WithOne(v => v.Customer).HasForeignKey(v => v.CustomerId).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
