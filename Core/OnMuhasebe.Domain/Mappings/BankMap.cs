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
            builder.Property(b => b.AccountCode).HasMaxLength(50);
            builder.Property(b => b.AccountName).HasMaxLength(100);
            builder.Property(b => b.BankName).HasMaxLength(100);
            builder.Property(b => b.Branch).HasMaxLength(100);
            builder.Property(b => b.IbanNo).HasMaxLength(26);
            builder.Property(b => b.AccountNo).HasMaxLength(20);
            builder.Property(b => b.AuthName).HasMaxLength(100);
            builder.Property(b => b.AuthPhone).HasMaxLength(20);

        }
    }
}
