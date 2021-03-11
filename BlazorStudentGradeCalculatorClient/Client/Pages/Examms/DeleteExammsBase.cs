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

namespace BlazorStudentGradeCalculatorClient.Client.Pages.Examms
{
    public class DeleteExammsBase : ComponentBase
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

        public List<Examm> ExammsT { get; set; } = new List<Examm>();

        protected ConfirmDelete DeleteConfirmation { get; set; }

        public bool HideButtons { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            ExammT = await ExammService.GetById(Id);


            Mapper.Map(ExammT, Examm);

        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }

        protected async Task DeleteExamm(bool deleteConfirmed)
        {       
            Mapper.Map(Examm, ExammT);

            if (deleteConfirmed)
            {                                
                await ExammService.DeleteEntity(Id);

                var schId = ExammT.SchoolIdNumber;

                if (ExammsT != null) await  UpdateNumberofSubjects(schId);

            }

            NavigationManager.NavigateTo("/listExamms");
         
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listExamms");
        }

        private async Task UpdateNumberofSubjects(string SchId)
        {
            ExammsT = (await ExammService.Search(SchId)).ToList();

            foreach (var item in ExammsT)
            {
                item.NumberOfSubjects -= 1;
            }

            await ExammService.UpdateEntities(ExammsT);
        }

    }
}
