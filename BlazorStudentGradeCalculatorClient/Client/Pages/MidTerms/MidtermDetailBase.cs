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
    public class MidtermDetailBase : ComponentBase
    {
        [Inject]
        public IMidTermService MidTermService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public string SchoolId { get; set; }

        public List<MidTermView> MidTerms { get; set; } = new List<MidTermView>();

        public List<MidTerm> MidTermsT { get; set; } = new List<MidTerm>();

        protected async override Task OnInitializedAsync()
        {            
            MidTermsT = (await MidTermService.Search(SchoolId)).ToList();


            Mapper.Map(MidTermsT, MidTerms);
        }
    }
}
