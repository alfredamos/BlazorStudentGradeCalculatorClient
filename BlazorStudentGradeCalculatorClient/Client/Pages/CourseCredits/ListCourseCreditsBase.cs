using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Pages.CourseCredits
{
    public class ListCourseCreditsBase : ComponentBase
    {
        [Inject]
        public ICourseCreditService CourseCreditService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<CourseCredit> CourseCreditsDB { get; set; } = new List<CourseCredit>();

        public List<CourseCreditView> CourseCredits { get; set; } = new List<CourseCreditView>();

        protected async override Task OnInitializedAsync()
        {
            CourseCreditsDB = (await CourseCreditService.GetAll()).ToList();

            Mapper.Map(CourseCreditsDB, CourseCredits);
        }
       
        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listCourseCredits");
        }
    }
}
