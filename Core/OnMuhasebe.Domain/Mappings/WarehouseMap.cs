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
    public class WarehouseMap : BaseModelMap, IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {

            builder.Property(w => w.WarehouseName).HasMaxLength(255);
            builder.Property(w => w.WarehouseCode).HasMaxLength(50);
            builder.Property(w => w.AuthCode).HasMaxLength(50);
            builder.Property(w => w.AuthName).HasMaxLength(255);
            builder.Property(w => w.Country).HasMaxLength(100);
            builder.Property(w => w.City).HasMaxLength(100);
            builder.Property(w => w.District).HasMaxLength(100);
            builder.Property(w => w.Address).HasMaxLength(500);
            builder.Property(w => w.Phone).HasMaxLength(20);


        }
    }
}
