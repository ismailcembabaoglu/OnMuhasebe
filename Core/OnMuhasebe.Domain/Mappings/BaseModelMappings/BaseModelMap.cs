using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Mappings.BaseModelMappings
{
    public class BaseModelMap: BaseModel
    {
        public void Configure(EntityTypeBuilder<BaseModel> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CreatedAt);
            builder.Property(b => b.UpdatedAt);
            builder.Property(b => b.CreatedUser);
            builder.Property(b => b.UpdatedUser);
            builder.Property(b => b.IsDeleted);
            builder.Property(b => b.Description);
        }

    }
}
