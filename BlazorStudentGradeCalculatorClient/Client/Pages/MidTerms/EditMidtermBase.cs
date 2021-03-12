using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Pages.MidTerms
{
    public class EditMidtermBase : ComponentBase
    {
        [Inject]
        public IMidTermService MidTermService { get; set; }

        [Inject]
        public IUtility Utility { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public MidTerm MidTermT { get; set; } = new MidTerm();

        public MidTermView MidTerm { get; set; } = new MidTermView();

        public bool HideButtons { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            MidTermT = await MidTermService.GetById(Id);

            Mapper.Map(MidTermT, MidTerm);

            Utility.OnChange += StateHasChanged;
        }

        protected async Task UpdateMidTerm()
        {
            MidTerm.SubjectScoreInLetter = Utility.GradeFetcher(MidTerm.SubjectScore);

            Mapper.Map(MidTerm, MidTermT);

            var midTerm = await MidTermService.UpdateEntity(MidTermT);

            if (midTerm != null)
            {
                NavigationManager.NavigateTo("/listMidterms");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listMidterms");
        }

    }
}
