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
    public class FastSaleGroupMap : BaseModelMap, IEntityTypeConfiguration<FastSaleGroup>
    {
        public void Configure(EntityTypeBuilder<FastSaleGroup> builder)
        {
            builder.Property(fsg => fsg.GroupName).HasMaxLength(255);
        }
    }
}
