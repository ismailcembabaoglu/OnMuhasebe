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
    public class SpecialCodeMap : BaseModelMap, IEntityTypeConfiguration<SpecialCode>
    {
        public void Configure(EntityTypeBuilder<SpecialCode> builder)
        {
            builder.Property(sc => sc.SpecialName);

          
        }
    }
}
