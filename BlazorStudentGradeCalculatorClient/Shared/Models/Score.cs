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
        public string SubjectName { get; set; }
        public double SubjectScore { get; set; }
        public string SubjectScoreInLetter { get; set; }

       public int ExammID { get; set; }
       public Examm Examm { get; set; }

       public int MidTermID { get; set; }
       public MidTerm MidTerm { get; set; }

    }
}
