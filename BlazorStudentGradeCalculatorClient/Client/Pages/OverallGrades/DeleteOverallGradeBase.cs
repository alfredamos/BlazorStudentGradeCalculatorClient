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

namespace BlazorStudentGradeCalculatorClient.Client.Pages.OverallGrades
{
    public class DeleteOverallGradeBase : ComponentBase
    {
        [Inject]
        public IOverallGradeService OverallGradeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public OverallGrade OverallGradeDB { get; set; } = new OverallGrade();

        public OverallGradeView OverallGrade { get; set; } = new OverallGradeView();

        protected ConfirmDelete DeleteConfirmation { get; set; }

        protected async override Task OnInitializedAsync()
        {
            OverallGradeDB = await OverallGradeService.GetById(Convert.ToInt32(Id));

            Mapper.Map(OverallGradeDB, OverallGrade);
        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }


        protected async Task DeleteOverallGrade(bool deleteConfirmed)
        {
            Mapper.Map(OverallGrade, OverallGradeDB);

            if (deleteConfirmed)
            {
                await OverallGradeService.DeleteEntity(Id);
            }

            NavigationManager.NavigateTo("/listOverallGrades");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listOverallGrades");
        }
    }
}
