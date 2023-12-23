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
    public class ProductMap : BaseModelMap, IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.IsActive);
            builder.Property(p => p.ProductNumber);
            builder.Property(p => p.Barcode);
            builder.Property(p => p.Brand);
            builder.Property(p => p.Model);
            builder.Property(p => p.GuaranteePeriod);
            builder.Property(p => p.Producer);
            builder.Property(p => p.Photo);

        }
    }
}
