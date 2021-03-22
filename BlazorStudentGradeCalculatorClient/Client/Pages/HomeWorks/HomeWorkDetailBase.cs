using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Pages.HomeWorks
{
    public class HomeWorkDetailBase : ComponentBase
    {
        [Inject]
        public IHomeWorkService HomeWorkService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public string SchoolId { get; set; }

        public List<HomeWork> HomeWorksT { get; set; } = new List<HomeWork>();

        public List<HomeWorkView> HomeWorks { get; set; } = new List<HomeWorkView>();

        public HomeWorkView HomeWorkTemp { get; set; } = new HomeWorkView();

        protected async override Task OnInitializedAsync()
        {
            HomeWorksT = (await HomeWorkService.Search(SchoolId)).ToList();

            Mapper.Map(HomeWorksT, HomeWorks);
        }

    }
}
