using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class ScoreView
    {
        public int ScoreID { get; set; }       
        public string SubjectName { get; set; }
        public double SubjectScore { get; set; }
        public string SubjectScoreInLetter { get; set; }

        public int ExammID { get; set; }
        public ExammView Examm { get; set; }

        public int MidTermID { get; set; }
        public MidTermView MidTerm { get; set; }

    }
}
