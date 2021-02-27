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
        public Examm Examm { get; set; }
        public HomeWork HomeWork { get; set; }
        public MidTerm MidTerm { get; set; }
    }
}
