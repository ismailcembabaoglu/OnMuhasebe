﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Mappings
{
    public class FastSaleGroupMap : IEntityTypeConfiguration<FastSaleGroup>
    {
        public void Configure(EntityTypeBuilder<FastSaleGroup> builder)
        {
            builder.HasKey(fsg => fsg.Id);
            builder.Property(fsg => fsg.GroupName).HasMaxLength(255).IsRequired();
        }
    }
}
