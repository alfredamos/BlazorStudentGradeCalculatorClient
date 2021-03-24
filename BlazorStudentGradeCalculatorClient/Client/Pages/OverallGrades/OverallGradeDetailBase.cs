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
    public class OverallGradeDetailBase : ComponentBase
    {
        [Inject]
        public IOverallGradeService OverallGradeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public string SchoolId { get; set; }

        public List<OverallGrade> OverallGradesDB { get; set; } = new List<OverallGrade>();

        public List<OverallGradeView> OverallGrades { get; set; } = new List<OverallGradeView>();

        protected async override Task OnInitializedAsync()
        {
            OverallGradesDB = (await OverallGradeService.Search(SchoolId)).ToList();

            Mapper.Map(OverallGradesDB, OverallGrades);
        }
    }
}
