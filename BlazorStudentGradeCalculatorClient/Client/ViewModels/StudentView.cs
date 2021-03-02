using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class StudentView
    {
        public int StudentID { get; set; }
        public string SchoolIdNumber { get; set; }
        public string StudentName { get; set; }
        public List<ExammView> Examms { get; set; }
        public List<HomeWorkView> HomeWorks { get; set; }
        public List<MidTermView> MidTerms { get; set; }

    }
}
