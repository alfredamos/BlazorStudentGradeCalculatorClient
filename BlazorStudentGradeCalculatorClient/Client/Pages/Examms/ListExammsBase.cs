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
    public class ListExammsBase : ComponentBase
    {
        [Inject]
        public IExammService ExammService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<Examm> ExammsT { get; set; } = new List<Examm>();

        public List<ExammView> Examms { get; set; } = new List<ExammView>();

        public ExammView ExampTemp { get; set; } = new ExammView();

        protected async override Task OnInitializedAsync()
        {
            ExammsT = (await ExammService.GetAll()).ToList();

            Mapper.Map(ExammsT, Examms);
        }
       
    }
}
