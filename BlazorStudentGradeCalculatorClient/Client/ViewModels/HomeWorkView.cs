using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class HomeWorkView 
    {
        public int HomeWorkID { get; set; }
        public string SchoolIdNumber { get; set; }
        public string StudentName { get; set; }

        public List<HWScoreView> Scores { get; set; }

        public int StudentID { get; set; }
        public StudentView Student { get; set; }

    }
}
