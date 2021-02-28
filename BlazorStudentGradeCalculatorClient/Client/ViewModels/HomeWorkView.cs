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

        public List<ScoreView> Scores { get; set; }

        public int StudentHomeWorkID { get; set; }
        public StudentView Student { get; set; }
    }
}
