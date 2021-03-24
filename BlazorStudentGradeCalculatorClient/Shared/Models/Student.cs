using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Shared.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string SchoolIdNumber { get; set; }
        public string StudentName { get; set; }
        public int NumberOfSubjects { get; set; }
        public double GPA { get; set; }
        public List<Examm> Examms { get; set; }
        public List<HomeWork> HomeWorks { get; set; }
        public List<MidTerm> MidTerms { get; set; }
        public List<OverallGrade> OverallGrades { get; set; }
    }
}
