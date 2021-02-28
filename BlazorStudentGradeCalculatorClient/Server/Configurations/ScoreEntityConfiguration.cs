using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Server.Configurations
{
    public class ScoreEntityConfiguration : IEntityTypeConfiguration<HWScore>
    {
        public void Configure(EntityTypeBuilder<HWScore> builder)
        {
           
            builder.HasOne(x => x.HomeWork)
            .WithMany(x => x.Scores)
            .HasForeignKey(x => x.HomeWorkScoreID);
         
        }
    }
}
