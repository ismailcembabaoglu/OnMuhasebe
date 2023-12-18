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
    public class EmployeeMotionMap : BaseModelMap, IEntityTypeConfiguration<EmployeeMotion>
    {
        public void Configure(EntityTypeBuilder<EmployeeMotion> builder)
        {
            builder.Property(em => em.EmployeeId).IsRequired();
            builder.Property(em => em.Period).IsRequired();
            builder.Property(em => em.PrimRatio).HasPrecision(18, 2).IsRequired();
            builder.Property(em => em.TotalAmount).HasPrecision(18, 2).IsRequired();
            builder.Property(em => em.MonthlySalary).HasPrecision(18, 2).IsRequired();

            builder.HasOne(em => em.Employee).WithMany(e => e.EmployeeMotions).HasForeignKey(em => em.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
