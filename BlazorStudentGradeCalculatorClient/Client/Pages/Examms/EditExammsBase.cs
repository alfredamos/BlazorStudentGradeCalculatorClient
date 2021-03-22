using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Pages.Examms
{
    public class EditExammsBase : ComponentBase
    {
        [Inject]
        public IExammService ExammService { get; set; }

        [Inject]
        public IUtility Utility { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public Examm ExammT { get; set; } = new Examm();

        public ExammView Examm { get; set; } = new ExammView();

        public bool HideButtons { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            ExammT = await ExammService.GetById(Id);

            Mapper.Map(ExammT, Examm);

            Utility.OnChange += StateHasChanged;
        }

        protected async Task UpdateExamm()
        {
            Examm.SubjectScoreInLetter = Utility.GradeFetcher(Examm.SubjectScore);

            Mapper.Map(Examm, ExammT);

            var examm = await ExammService.UpdateEntity(ExammT);

            if (examm != null)
            {
                NavigationManager.NavigateTo("/listExamms");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listExamms");
        }
 
    }
}
