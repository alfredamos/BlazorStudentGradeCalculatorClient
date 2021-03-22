using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Helpers
{
    public class HWUtility : IHWUtility
    {
        private string SubjectName; 
        public HomeWorkView HomeWorkInfo(HomeWorkView homeWork, List<HWScoreView> scores)
        {
            var averageScore = CalculateScoreAverage(scores);

            return new HomeWorkView
            {
                SchoolIdNumber = homeWork.SchoolIdNumber,
                StudentName = homeWork.StudentName,
                SubjectName = SubjectName,
                SubjectScore = averageScore,
                SubjectScoreInLetter = GradeFetcher(averageScore),
                NumberOfSubjects = homeWork.NumberOfSubjects,
                NumberOfHomeWorks = homeWork.NumberOfHomeWorks,
                Scores = scores,

            };
        }

        public HWScoreView ScoreInfo(HWScoreView score)
        {         
            var grade = GradeLetter(score.SubjectScore);

            return new HWScoreView
            {
                SubjectName = score.SubjectName,
                SubjectScore = score.SubjectScore,
                SubjectScoreInLetter = grade
            };
        }

        private double CalculateScoreAverage(List<HWScoreView> scores)
        {
            var sum = 0.0;
            var totalNumb = 0;

            foreach (var item in scores)
            {
                sum += item.SubjectScore;
                totalNumb += 1;

            }
            SubjectName = scores[0].SubjectName;
            return sum / totalNumb;
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

        public double AverageScoreCalculator(List<HWScoreView> scores)
        {
            return CalculateScoreAverage(scores);
        }
    }
}
