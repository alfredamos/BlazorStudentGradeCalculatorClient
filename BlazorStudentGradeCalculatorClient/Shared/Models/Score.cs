using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Shared.Models
{
    public class Score
    {
        public int ScoreID { get; set; }
        public string SchoolIdNumber { get; set; }
        public string SCoreName { get; set; }
        public double ScoreGrade { get; set; }
        public string ScoreInLetter { get; set; }

        public int MidTermScoreID { get; set; }
        public MidTerm MidTerm { get; set; }

        public int ExammsScoreID { get; set; }
        public Examm Examm { get; set; }

        public int HomeWorkScoreID { get; set; }
        public HomeWork HomeWork { get; set; }

    }
}
