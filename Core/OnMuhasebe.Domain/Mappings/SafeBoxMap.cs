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
    public class SafeBoxMap : IEntityTypeConfiguration<SafeBoxMap>
    {
        public void Configure(EntityTypeBuilder<SafeBoxMap> builder)
        {
            throw new NotImplementedException();
        }
    }
}