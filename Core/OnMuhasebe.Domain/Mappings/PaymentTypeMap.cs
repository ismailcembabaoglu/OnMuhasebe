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
    public class PaymentTypeMap :BaseModelMap, IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {

            builder.Property(pt => pt.PaymentTypeCode).HasMaxLength(50);
            builder.Property(pt => pt.PaymentTypeName).HasMaxLength(255);

           
        }
    }
}
