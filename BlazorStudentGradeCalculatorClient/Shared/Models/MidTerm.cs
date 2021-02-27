using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Shared.Models
{
    public class MidTerm
    {
        public int MidTermID { get; set; }
        public string SchoolIdNumber { get; set; }
        public string StudentName { get; set; }
        public int MyProperty { get; set; }

        public Score Score { get; set; }

        public int StudentMidTermID { get; set; }
        public Student Student { get; set; }
    }
}
