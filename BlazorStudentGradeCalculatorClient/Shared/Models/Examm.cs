using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Shared.Models
{
    public class Examm
    {
        public int ExammID { get; set; }
        public string SchoolIdNumber { get; set; }
        public string StudentName { get; set; }
       
        public Score Score { get; set; }

        public int StudentExammsID { get; set; }
        public Student Student { get; set; }
    }
}
