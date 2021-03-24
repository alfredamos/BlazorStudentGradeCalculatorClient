using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Server.Configurations
{
    public class OverallGradeConfiguration : IEntityTypeConfiguration<OverallGrade>
    {
        public void Configure(EntityTypeBuilder<OverallGrade> builder)
        {
            builder.HasOne(x => x.Student)
            .WithMany(x => x.OverallGrades)
            .HasForeignKey(x => x.StudentID);
        }
    }
}
