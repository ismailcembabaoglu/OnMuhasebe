﻿using Microsoft.EntityFrameworkCore;
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
    public class PriceMap : BaseModelMap, IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            // Price sınıfına özgü özellikleri ve ilişkileri ayarla
            builder.Property(p => p.PriceType);
            builder.Property(p => p.PriceValue).HasPrecision(18, 2);
            builder.Property(p => p.IsDefault);

            // Product ile ilişki
            builder.HasOne(p => p.Product).WithMany(p => p.Prices).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);

            // Kdv ile ilişki
            builder.HasOne(p => p.Kdv).WithMany(k => k.Prices).HasForeignKey(p => p.KdvId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
