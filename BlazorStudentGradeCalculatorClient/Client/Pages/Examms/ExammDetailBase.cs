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
    public class ExammDetailBase : ComponentBase
    {
        [Inject]
        public IExammService ExammService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public string SchoolId { get; set; }

        public List<ExammView> Examms { get; set; } = new List<ExammView>();

        public List<Examm> ExammsT { get; set; } = new List<Examm>();

        protected async override Task OnInitializedAsync()
        {           
            ExammsT = (await ExammService.Search(SchoolId)).ToList();
           

            Mapper.Map(ExammsT, Examms);
        }
    }
}
