using BlazorStudentGradeCalculatorClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class ExammView 
    {
        public int ExammID { get; set; }
        [Required]
        public string SchoolIdNumber { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public double SubjectScore { get; set; }
        public string SubjectScoreInLetter { get; set; }
        [Required]
        public int NumberOfSubjects { get; set; }

        public int? StudentID { get; set; }
        public StudentView Student { get; set; }

    }
}
