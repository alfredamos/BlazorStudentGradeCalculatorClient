using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Shared.Models
{
    public class HWScore
    {
        public int HWScoreID { get; set; }
        public string SchoolIdNumber { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public double SubjectScore { get; set; }
        public string SubjectScoreInLetter { get; set; }

        public int HomeWorkScoreID { get; set; }
        public HomeWork HomeWork { get; set; }

    }
}
