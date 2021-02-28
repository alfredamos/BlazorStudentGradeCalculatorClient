using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Shared.Models
{
    public class HomeWork : Score
    {
        public int HomeWorkID { get; set; }
        
        public List<HWScore> Scores { get; set; }

        public int StudentHomeWorkID { get; set; }
        public Student Student { get; set; }
    }
}
