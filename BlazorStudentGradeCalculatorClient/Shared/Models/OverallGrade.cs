﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Shared.Models
{
    public class OverallGrade
    {
        public int OverallGradeID { get; set; }
        public string SchoolIdNumber { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public double SubjectScore { get; set; }
        public string SubjectScoreInLetter { get; set; }
        public int NumberOfSubjects { get; set; }
        //public Examm Examm { get; set; }
        //public MidTerm MidTerm { get; set; }
        //public HomeWork HomeWork { get; set; }

        public int? StudentID { get; set; }
        public Student Student { get; set; }
    }
}
