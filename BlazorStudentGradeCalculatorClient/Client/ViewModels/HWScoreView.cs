using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class HWScoreView
    {
        public int HWScoreID { get; set; }       
        public string SubjectName { get; set; }
        public double SubjectScore { get; set; }
        public string SubjectScoreInLetter { get; set; }

        public int HomeWorkID { get; set; }
        public HomeWorkView HomeWork { get; set; }
       
    }
}
