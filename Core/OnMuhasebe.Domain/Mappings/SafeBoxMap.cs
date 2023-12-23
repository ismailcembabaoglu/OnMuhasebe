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
    public class SafeBoxMap : BaseModelMap, IEntityTypeConfiguration<SafeBox>
    {
        public void Configure(EntityTypeBuilder<SafeBox> builder)
        {
            builder.Property(sb => sb.SafeBoxCode);
            builder.Property(sb => sb.SafeBoxName);
            builder.Property(sb => sb.AuthCode);
            builder.Property(sb => sb.AuthName);

           
        }
    }
}
