using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.Shared;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Pages.MidTerms
{
    public class DeleteMidtermBase : ComponentBase
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

        public List<MidTerm> MidTermsT { get; set; } = new List<MidTerm>();

        protected ConfirmDelete DeleteConfirmation { get; set; }

        public bool HideButtons { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            MidTermT = await MidTermService.GetById(Id);


            Mapper.Map(MidTermT, MidTerm);

        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }

        protected async Task DeleteMidTerm(bool deleteConfirmed)
        {
            Mapper.Map(MidTerm, MidTermT);

            if (deleteConfirmed)
            {
                await MidTermService.DeleteEntity(Id);

                var schId = MidTermT.SchoolIdNumber;

                if (MidTermsT != null) await UpdateNumberofSubjects(schId);

            }

            NavigationManager.NavigateTo("/listMidterms");

        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listMidterms");
        }

        private async Task UpdateNumberofSubjects(string SchId)
        {
            MidTermsT = (await MidTermService.Search(SchId)).ToList();

            foreach (var item in MidTermsT)
            {
                item.NumberOfSubjects -= 1;
            }

            await MidTermService.UpdateEntities(MidTermsT);
        }

    }
}
