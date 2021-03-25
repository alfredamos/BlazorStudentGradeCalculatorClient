using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Shared.Models
{
    public class CourseCredit
    {
        public int CourseCreditID { get; set; }
        public string GradeLetter { get; set; }
        public double GradeCredit { get; set; }
    }
}
