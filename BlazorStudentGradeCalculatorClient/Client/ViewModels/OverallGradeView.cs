using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class OverallGradeView
    {
        public int OverallGradeID { get; set; }
        public string SchoolIdNumber { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public double SubjectScore { get; set; }
        public string SubjectScoreInLetter { get; set; }
        public int NumberOfSubjects { get; set; }
       
        public int? StudentID { get; set; }
        public StudentView Student { get; set; }
    }
}
