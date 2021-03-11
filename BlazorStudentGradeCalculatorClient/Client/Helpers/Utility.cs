using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Helpers
{
    public class Utility : IUtility
    {
        public event Action OnChange;
        private List<ExammView> Examms = new List<ExammView>();

        public List<ExammView> ExammList(ExammView examm)
        {
            Examms.Add(
            new ExammView
            {
                NumberOfSubjects = examm.NumberOfSubjects,
                SchoolIdNumber = examm.SchoolIdNumber,
                StudentName = examm.StudentName,
                SubjectScore = examm.SubjectScore,
                SubjectName = examm.SubjectName,
                SubjectScoreInLetter = examm.SubjectScoreInLetter,
                //StudentID = 2
            }) ;

            NotifyDataChanged();

            return Examms;
        }

        public string GradeFetcher(double score)
        {
            return GradeLetter(score);
        }

        private string GradeLetter(double gl)
        {

            string gradeInLetter = "";

            if (gl >= 90) gradeInLetter = "A+";
            else if (gl >= 85 && gl < 90) gradeInLetter = "A";
            else if (gl >= 80 && gl < 85) gradeInLetter = "A-";
            else if (gl >= 75 && gl < 80) gradeInLetter = "B+";
            else if (gl >= 70 && gl < 75) gradeInLetter = "B";
            else if (gl >= 65 && gl < 70) gradeInLetter = "B-";
            else if (gl >= 60 && gl < 65) gradeInLetter = "C+";
            else if (gl >= 55 && gl < 60) gradeInLetter = "C";
            else if (gl >= 50 && gl < 55) gradeInLetter = "C-";
            else if (gl >= 45 && gl < 50) gradeInLetter = "D";
            else if (gl < 45) gradeInLetter = "F";

            return gradeInLetter;

        }

        private void NotifyDataChanged() => OnChange.Invoke();

        public void ClearList(List<ExammView> examms)
        {
            examms.Clear();
            NotifyDataChanged();
        }
    }
}
