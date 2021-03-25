using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class CourseCreditView
    {
        public int CourseCreditID { get; set; }
        public string GradeLetter { get; set; }
        public double GradeCredit { get; set; }
    }
}
