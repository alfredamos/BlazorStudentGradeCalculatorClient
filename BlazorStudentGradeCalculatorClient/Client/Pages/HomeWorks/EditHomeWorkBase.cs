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
    public class EditHomeWorkBase : ComponentBase
    {
        [Inject]
        public IHomeWorkService HomeWorkService { get; set; }

        [Inject]
        public IHWUtility Utility { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public HomeWork HomeWorkT { get; set; } = new HomeWork();

        public HomeWorkView HomeWork { get; set; } = new HomeWorkView();

        public List<HomeWork> HomeWorksT { get; set; } = new List<HomeWork>();

        public List<HomeWorkView> HomeWorks { get; set; } = new List<HomeWorkView>();

        public List<HWScoreView> Scores { get; set; } = new List<HWScoreView>();

        public List<HWScore> ScoresT { get; set; } = new List<HWScore>();

        public bool HideButtons { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            HomeWorkT = await HomeWorkService.GetById(Id);

            ScoresT = HomeWorkT.Scores;

            Mapper.Map(ScoresT, Scores);

            Mapper.Map(HomeWorkT, HomeWork);

        }

        protected async Task UpdateHomeWork()
        {
            LetterGradeUpdater(Scores);
            HomeWork.Scores = Scores;            
            var averageScore = Utility.AverageScoreCalculator(Scores);
            HomeWork.SubjectScore = averageScore;
            HomeWork.SubjectScoreInLetter = Utility.GradeFetcher(averageScore);
            HomeWorks.Add(HomeWork);

            Mapper.Map(HomeWorks, HomeWorksT);

            await HomeWorkService.UpdateEntities(HomeWorksT);

            NavigationManager.NavigateTo("/listHomeWorks");

        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listHomeWorks");
        }

        private void LetterGradeUpdater(List<HWScoreView> scores)
        {
            foreach (var item in scores)          
                item.SubjectScoreInLetter = Utility.GradeFetcher(item.SubjectScore);
                   
        }

    }
}

