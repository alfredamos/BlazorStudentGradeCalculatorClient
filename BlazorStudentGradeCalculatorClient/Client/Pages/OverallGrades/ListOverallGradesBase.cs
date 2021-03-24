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
    public class ListOverallGradesBase : ComponentBase
    {
        [Inject]
        public IOverallGradeService MidTermService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<OverallGrade> OverallGradesT { get; set; } = new List<OverallGrade>();

        public List<OverallGradeView> OverallGrades { get; set; } = new List<OverallGradeView>();

        public OverallGradeView OverallGradeTemp { get; set; } = new OverallGradeView();

        protected async override Task OnInitializedAsync()
        {
            OverallGradesT = (await MidTermService.GetAll()).ToList();

            Mapper.Map(OverallGradesT, OverallGrades);
        }

    }
}
