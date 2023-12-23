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
    public class EmployeeMap : BaseModelMap, IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.IsWork);
            builder.Property(e => e.EmployeeTitle).HasMaxLength(50);
            builder.Property(e => e.EmployeeCode).HasMaxLength(20);
            builder.Property(e => e.EmployeeName).HasMaxLength(100);
            builder.Property(e => e.IdentityNo).HasMaxLength(20);
            builder.Property(e => e.WorkStartDate);
            builder.Property(e => e.WorkOutDate);
            builder.Property(e => e.TaskOffice).HasMaxLength(50);
            builder.Property(e => e.TaskNo).HasMaxLength(20);
            builder.Property(e => e.MobilePhone).HasMaxLength(20);
            builder.Property(e => e.Phone).HasMaxLength(20);
            builder.Property(e => e.Fax).HasMaxLength(20);
            builder.Property(e => e.Email).HasMaxLength(100);
            builder.Property(e => e.Website).HasMaxLength(100);
            builder.Property(e => e.Country).HasMaxLength(50);
            builder.Property(e => e.City).HasMaxLength(50);
            builder.Property(e => e.District).HasMaxLength(50);
            builder.Property(e => e.Address).HasMaxLength(200);
            builder.Property(e => e.PrimRatio).HasPrecision(18, 2);
            builder.Property(e => e.MonthlySalary).HasPrecision(18, 2);

        }
    }
}
