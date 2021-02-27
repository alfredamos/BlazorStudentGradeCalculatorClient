using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Server.Configurations
{
    public class MidTermEntityConfiguration : IEntityTypeConfiguration<MidTerm>
    {
        public void Configure(EntityTypeBuilder<MidTerm> builder)
        {
            builder.HasOne(x => x.Student)
            .WithOne(x => x.MidTerm)
            .HasForeignKey<MidTerm>(x => x.StudentMidTermID);
        }
    }
}
