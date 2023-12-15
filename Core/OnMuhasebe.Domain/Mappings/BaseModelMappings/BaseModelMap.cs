﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnMuhasebe.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Mappings.BaseModelMappings
{
    public class BaseModelMap : IEntityTypeConfiguration<BaseModelMap>
    {
        public void Configure(EntityTypeBuilder<BaseModelMap> builder)
        {

        }
    }
}