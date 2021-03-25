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
        public string StudentName { get; set; }        
        public int NumberOfSubjects { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public double GPA { get; set; }
        public List<ExammView> Examms { get; set; }
        public List<HomeWorkView> HomeWorks { get; set; }
        public List<MidTermView> MidTerms { get; set; }
        public List<OverallGradeView> OverallGrades { get; set; }

    }
}
