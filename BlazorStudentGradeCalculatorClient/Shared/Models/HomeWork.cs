using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Shared.Models
{
    public class HomeWork
    {
        public int HomeWorkID { get; set; }
        public string SchoolIdNumber { get; set; }
        public string StudentName { get; set; }

        public List<Score> Scores { get; set; }

        public int StudentHomeWorkID { get; set; }
        public Student Student { get; set; }
    }
}
