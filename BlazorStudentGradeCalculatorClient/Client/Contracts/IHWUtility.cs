using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Contracts
{
    public interface IHWUtility
    {
        HomeWorkView HomeWorkInfo(HomeWorkView homeWork, List<HWScoreView> scores);
        HWScoreView ScoreInfo(HWScoreView score);
        public string GradeFetcher(double score);
        double AverageScoreCalculator(List<HWScoreView> scores);
    }
}
