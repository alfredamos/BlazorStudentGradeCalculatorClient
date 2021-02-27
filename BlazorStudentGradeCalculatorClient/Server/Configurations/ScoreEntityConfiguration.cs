using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Server.Configurations
{
    public class ScoreEntityConfiguration : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.HasOne(x => x.Examm)
            .WithOne(x => x.Score)
            .HasForeignKey<Score>(x => x.ExammsScoreID);

            builder.HasOne(x => x.HomeWork)
            .WithMany(x => x.Scores)
            .HasForeignKey(x => x.HomeWorkScoreID);

            builder.HasOne(x => x.MidTerm)
            .WithOne(x => x.Score)
            .HasForeignKey<Score>(x => x.MidTermScoreID);
        }
    }
}
