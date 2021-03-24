using System;
using System.Collections.Generic;
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
        public double SubjectScore { get; set; }
        public string SubjectScoreInLetter { get; set; }
        public int NumberOfSubjects { get; set; }
        //public ExammView Examm { get; set; }
        //public MidTermView MidTerm { get; set; }
        //public HomeWorkView HomeWork { get; set; }

        public int? StudentID { get; set; }
        public StudentView Student { get; set; }
    }
}
