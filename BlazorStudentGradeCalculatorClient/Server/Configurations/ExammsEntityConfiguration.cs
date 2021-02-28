using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Server.Configurations
{
    public class ExammsEntityConfiguration : IEntityTypeConfiguration<Examm>
    {
        public void Configure(EntityTypeBuilder<Examm> builder)
        {
            builder.HasOne(x => x.Student)
            .WithMany(x => x.Examms)
            .HasForeignKey(x => x.StudentExammsID);
        }
    }
}
