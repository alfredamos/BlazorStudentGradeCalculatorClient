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
        List<MidTermView> MidTermList(MidTermView midTerm);
        void ClearList(List<MidTermView> midTerms);
        //List<HomeWorkView> HomeWorkList(HomeWorkView homeWork);
        //void ClearList(List<HomeWorkView> homeWorks);
        //List<StudentView> StudentList(StudentView student);
        //void ClearList(List<StudentView> students);

    }
}
