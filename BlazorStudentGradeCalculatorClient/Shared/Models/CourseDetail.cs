using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Shared.Models
{
    public class CourseDetail
    {
        public int CourseDetailID { get; set; }
        public string SubjectName { get; set; }
        public int SubjectWeight { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
    }
}
