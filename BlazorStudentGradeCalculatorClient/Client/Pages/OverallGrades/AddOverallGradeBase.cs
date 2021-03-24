using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Pages.OverallGrades
{
    public class AddOverallGradeBase : ComponentBase
    {
        [Inject]
        public IOverallGradeService OverallGradeService { get; set; }

        [Inject]
        public IExammService ExammService { get; set; }

        [Inject]
        public IHomeWorkService HomeWorkService { get; set; }

        [Inject]
        public IMidTermService MidTermService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public IHWUtility Utility { get; set; }

        public OverallGrade OverallGradeT { get; set; } = new OverallGrade();

        public OverallGradeView OverallGrade { get; set; } = new OverallGradeView();

        public List<OverallGradeView> OverallGrades { get; set; } = new List<OverallGradeView>();

        public List<OverallGrade> OverallGradesT { get; set; } = new List<OverallGrade>();

        public Examm Examm { get; set; } = new Examm();

        public List<ExammView> Examms { get; set; } = new List<ExammView>();

        public List<Examm> ExammsT { get; set; } = new List<Examm>();

        public HomeWork HomeWorkT { get; set; } = new HomeWork();

        public HomeWorkView HomeWork { get; set; } = new HomeWorkView();

        public List<HomeWork> HomeWorksT { get; set; } = new List<HomeWork>();

        public List<HomeWorkView> HomeWorks { get; set; } = new List<HomeWorkView>();

        public MidTerm MidTermT { get; set; } = new MidTerm();

        public MidTermView MidTerm { get; set; } = new MidTermView();

        public List<MidTerm> MidTermsT { get; set; } = new List<MidTerm>();

        public List<MidTermView> MidTerms { get; set; } = new List<MidTermView>();

        protected async Task CreateOverallGrade()
        {
            await StudentOverallGrade();

            Mapper.Map(OverallGrades, OverallGradesT);

            await OverallGradeService.AddEntities(OverallGradesT);

            OverallGrades.Clear();
            OverallGradesT.Clear();

            NavigationManager.NavigateTo("/listOverallGrades");
          
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listOverallGrades");
        }

        private async Task StudentOverallGrade()
        {
            var SchoolIdNumber = OverallGrade.SchoolIdNumber;
            ExammsT = (await ExammService.Search(SchoolIdNumber)).ToList();
            MidTermsT = (await MidTermService.Search(SchoolIdNumber)).ToList();
            HomeWorksT = (await HomeWorkService.Search(SchoolIdNumber)).ToList();

            Mapper.Map(ExammsT, Examms);
            Mapper.Map(HomeWorksT, HomeWorks);
            Mapper.Map(MidTermsT, MidTerms);

            foreach (var item in Examms)
            {                
                OverallGrade.SchoolIdNumber = item.SchoolIdNumber;
                OverallGrade.StudentName = item.StudentName;
                OverallGrade.NumberOfSubjects = item.NumberOfSubjects;
                OverallGrade.SubjectName = item.SubjectName;
                
                HomeWork = HomeWorks.FirstOrDefault(x => x.SubjectName == item.SubjectName);
                MidTerm = MidTerms.FirstOrDefault(x => x.SubjectName == item.SubjectName);

                Console.WriteLine("++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Subject Name : " + item.SubjectName);
                Console.WriteLine("Examm Score " + item.SubjectScore);
                Console.WriteLine("Home Work Score " + HomeWork.SubjectScore);
                Console.WriteLine("MidTerm Score " + MidTerm.SubjectScore);
                Console.WriteLine("++++++++++++++++++++++++++++++++++++");

                OverallGrade.SubjectScore = (HomeWork.SubjectScore + MidTerm.SubjectScore + item.SubjectScore) / 3;

                OverallGrade.SubjectScoreInLetter = Utility.GradeFetcher(OverallGrade.SubjectScore);

                OverallGrades.Add(OverallGrade);

                OverallGrade = new OverallGradeView();

            }
        }
    }
}
