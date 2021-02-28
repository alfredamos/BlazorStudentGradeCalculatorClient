using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Shared.Models
{
    public class MidTerm : Score
    {
        public int MidTermID { get; set; }
        
        public int StudentMidTermID { get; set; }
        public Student Student { get; set; }
    }
}
