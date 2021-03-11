using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class HomeWorkView 
    {
        public int HomeWorkID { get; set; }
        [Required]
        public string SchoolIdNumber { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public double SubjectScore { get; set; }
        public string SubjectScoreInLetter { get; set; }
        [Required]
        public int NumberOfSubjects { get; set; }

        public List<HWScoreView> Scores { get; set; }

        public int? StudentID { get; set; }
        public StudentView Student { get; set; }

    }
}
