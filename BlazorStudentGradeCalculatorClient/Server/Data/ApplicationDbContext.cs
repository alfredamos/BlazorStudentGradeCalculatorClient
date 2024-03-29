﻿using BlazorStudentGradeCalculatorClient.Server.Configurations;
using BlazorStudentGradeCalculatorClient.Server.Models;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ExammsEntityConfiguration());            
            builder.ApplyConfiguration(new HomeWorkEntityConfiguration());
            builder.ApplyConfiguration(new MidTermEntityConfiguration());
            builder.ApplyConfiguration(new HWScoreEntityConfiguration());
            builder.ApplyConfiguration(new OverallGradeConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<CourseCredit> CourseCredits { get; set; }
        public DbSet<CourseDetail> CourseWeights { get; set; }
        public DbSet<Examm> Examms { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<MidTerm> MidTerms { get; set; }
        public DbSet<HWScore> HWScores { get; set; }
        public DbSet<OverallGrade> OverallGrades { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
