using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class StudentView
    {
        public int StudentID { get; set; }
        [Required]
        public string SchoolIdNumber { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public int NumberOfSubjects { get; set; }
        public double GPA { get; set; }
        public List<ExammView> Examms { get; set; }
        public List<HomeWorkView> HomeWorks { get; set; }
        public List<MidTermView> MidTerms { get; set; }

    }
}
