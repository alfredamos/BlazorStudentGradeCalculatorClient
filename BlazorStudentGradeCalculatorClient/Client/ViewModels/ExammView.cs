using BlazorStudentGradeCalculatorClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class ExammView 
    {
        public int ExammID { get; set; }
        public string SchoolIdNumber { get; set; }
        public string StudentName { get; set; }

        public ScoreView Score { get; set; }

        public int StudentID { get; set; }
        public StudentView Student { get; set; }
       
    }
}
