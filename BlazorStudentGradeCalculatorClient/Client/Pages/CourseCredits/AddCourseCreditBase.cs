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
    public class AddCourseCreditBase : ComponentBase
    {
        [Inject]
        public ICourseCreditService CourseCreditService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public CourseCredit CourseCreditDB { get; set; } = new CourseCredit();

        public CourseCreditView CourseCredit { get; set; } = new CourseCreditView();

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected async Task CreateCourseCredit()
        {
            Mapper.Map(CourseCredit, CourseCreditDB);

            var courseCredit = await CourseCreditService.AddEntity(CourseCreditDB);

            if (courseCredit != null)
            {
                NavigationManager.NavigateTo("/listCourseCredits");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listCourseCredits");
        }
    }
}
