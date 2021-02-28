using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class ScoreView
    {
        public int ScoreID { get; set; }
        public string SchoolIdNumber { get; set; }
        public string SubjectName { get; set; }
        public double SubjectScore { get; set; }
        public string SubjectScoreInLetter { get; set; }

        public int MidTermScoreID { get; set; }
        public MidTermView MidTerm { get; set; }

        public int ExammsScoreID { get; set; }
        public ExammView Examm { get; set; }

        public int HomeWorkScoreID { get; set; }
        public HomeWorkView HomeWork { get; set; }
    }
}
