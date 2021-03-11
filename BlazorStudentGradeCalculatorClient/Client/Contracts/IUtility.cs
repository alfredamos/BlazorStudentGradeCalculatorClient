using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Contracts
{
    public interface IUtility
    {
        event Action OnChange;
        string GradeFetcher(double score);      
        List<ExammView> ExammList(ExammView examm);
        void ClearList(List<ExammView> examms);

    }
}
