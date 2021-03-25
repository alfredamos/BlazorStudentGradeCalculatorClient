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
    public class EditCourseCreditBase : ComponentBase
    {
        [Inject]
        public ICourseCreditService CourseCreditService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public CourseCredit CourseCreditDB { get; set; } = new CourseCredit();

        public CourseCreditView CourseCredit { get; set; } = new CourseCreditView();

        protected async override Task OnInitializedAsync()
        {
            CourseCreditDB = await CourseCreditService.GetById(Convert.ToInt32(Id));

            Mapper.Map(CourseCreditDB, CourseCredit);
        }

        protected async Task UpdateCourseCredit()
        {
            Mapper.Map(CourseCredit, CourseCreditDB);

            var courseCredit = await CourseCreditService.UpdateEntity(CourseCreditDB);

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
