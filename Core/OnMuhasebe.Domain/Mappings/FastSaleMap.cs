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
    public class FastSaleMap : BaseModelMap, IEntityTypeConfiguration<FastSale>
    {
        public void Configure(EntityTypeBuilder<FastSale> builder)
        {
            builder.Property(fs => fs.FastSaleGroupId);
            builder.Property(fs => fs.ProductId);
        }
    }
}
