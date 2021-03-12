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
    public class AddMidtermBase : ComponentBase
    {
        [Inject]
        public IMidTermService MidTermService { get; set; }

        [Inject]
        public IUtility Utility { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public MidTerm MidTermT { get; set; } = new MidTerm();

        public MidTermView MidTerm { get; set; } = new MidTermView();

        public List<MidTerm> MidTermsT { get; set; } = new List<MidTerm>();

        public List<MidTermView> MidTerms { get; set; } = new List<MidTermView>();

        public bool ShowComponent { get; set; } = true;

        public bool ShowMainForm { get; set; } = true;

        public bool HideButtons { get; set; } = false;

        public string SchoolID { get; set; }

        public string StudentName { get; set; }

        public int NumbOfSujects { get; set; }

        public int Kounter { get; set; } = 1;

        public int NumbTemp { get; set; }

        protected override void OnInitialized()
        {
            Utility.OnChange += StateHasChanged;

            Utility.ClearList(MidTerms);
        }

        protected async Task CreateMidterm()
        {
            MidTerms = ListOfMidterms(MidTerm);

            Mapper.Map(MidTerms, MidTermsT);

            await MidTermService.AddEntities(MidTermsT);

            Utility.ClearList(MidTerms);

            NavigationManager.NavigateTo("/listMidterms");
        }

        protected List<MidTermView> ListOfMidterms(MidTermView midTerm)
        {
            MidTerm.SubjectScoreInLetter = Utility.GradeFetcher(midTerm.SubjectScore);
            return Utility.MidTermList(midTerm);

        }

        protected void Proceed()
        {
            ShowMainForm = false;

            MidTerms = ListOfMidterms(MidTerm);

            MidTerm = new MidTermView();

            if (Kounter <= NumbTemp)
            {
                if (Kounter == NumbTemp) HideButtons = true;

                NavigationManager.NavigateTo("/addMidterm");

            }
            ++Kounter;
        }

        protected void Back()
        {
            ShowComponent = true;
            HideButtons = true;

        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listMidterms");
        }

    }
}
