using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Pages.HomeWorks
{
    public class AddHomeWorkBase : ComponentBase
    {
        [Inject]
        public IHomeWorkService HomeWorkService { get; set; }

        [Inject]
        IHWUtility Utility { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public HomeWork HomeWorkT { get; set; } = new HomeWork();

        public HomeWorkView HomeWork { get; set; } = new HomeWorkView();

        public List<HomeWork> HomeWorksT { get; set; } = new List<HomeWork>();

        public List<HomeWorkView> HomeWorks { get; set; } = new List<HomeWorkView>();

        public HWScoreView Score { get; set; } = new HWScoreView();

        public List<HWScoreView> Scores { get; set; } = new List<HWScoreView>();

        public Dictionary<int, List<HWScoreView>> DictOfScores = new();

        public List<HWScore> ScoresT { get; set; } = new List<HWScore>();

        public bool ShowComponent { get; set; } = true;

        public bool ShowMainForm { get; set; } = true;

        public bool ShowHWInput { get; set; } = true;

        public bool HideButtons { get; set; } = false;

        public bool ShowButton { get; set; } = true;

        public bool ShowStudentInfo { get; set; } = true;

        public string SchoolID { get; set; }

        public string StudentName { get; set; }

        public string SubjectName { get; set; }

        public int NumbOfSujects { get; set; }

        public int NumbOfHomeWorks { get; set; }

        public int KounterNumbOfHomeWork { get; set; } = 1; 

        public int KounterNumbOfSubjects { get; set; } = 1;

        public int NumbTempSubject { get; set; } = 0;

        public int NumbTempHomeWork { get; set; } = 0;

        protected override void OnInitialized()
        {
           
            Console.WriteLine("At initialization");
        }

        protected async Task CreateHomeWork(HWScoreView score)       
        {       
            Scores.Add(score);

            var homeWork = Utility.HomeWorkInfo(HomeWork, Scores);
           
            DictOfScores.Add(KounterNumbOfSubjects, Scores);
           
            HomeWorks.Add(homeWork);    

            Mapper.Map(HomeWorks, HomeWorksT);
          
            await HomeWorkService.AddEntities(HomeWorksT);

            Scores.Clear();
            HomeWorks.Clear();
            
            NavigationManager.NavigateTo("/listHomeWorks");
        }

        protected void Proceed(HWScoreView score)
        {            
            ShowMainForm = false;
                       
            if (KounterNumbOfHomeWork <= NumbTempHomeWork)
            {               
                Scores.Add(score);

                Score = new HWScoreView();

                if (KounterNumbOfHomeWork == NumbTempHomeWork)
                {                    
                    if (KounterNumbOfSubjects == NumbTempSubject)                 
                        HideButtons = true;                   
                    else
                    {
                        var homeWork = Utility.HomeWorkInfo(HomeWork, Scores);

                        HomeWorks.Add(homeWork);

                        HomeWork = new HomeWorkView();

                        KounterNumbOfSubjects++;
                        KounterNumbOfHomeWork = 0;

                        Scores = new List<HWScoreView>();

                        ShowMainForm = true;
                        ShowHWInput = false;

                        //NavigationManager.NavigateTo("/addHomeWork");

                    }
                }
                else                       
                    NavigationManager.NavigateTo("/addHomeWork");                        
            }
            ++KounterNumbOfHomeWork;
       
        }

        protected void Back()
        {
            ShowComponent = true;
            HideButtons = true;

        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listHomeWorks");
        }

    }
}
