using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Server.Configurations
{
    public class HomeWorkEntityConfiguration : IEntityTypeConfiguration<HomeWork>
    {
        public void Configure(EntityTypeBuilder<HomeWork> builder)
        {
            builder.HasOne(x => x.Student)
            .WithOne(x => x.HomeWork)
            .HasForeignKey<HomeWork>(x => x.StudentHomeWorkID);
        }
    }
}
