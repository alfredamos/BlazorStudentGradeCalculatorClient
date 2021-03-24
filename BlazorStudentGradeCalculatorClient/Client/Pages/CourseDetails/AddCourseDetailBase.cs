using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Pages.CourseDetails
{
    public class AddCourseDetailBase : ComponentBase
    {
        [Inject]
        public ICourseDetailService CourseDetailService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public CourseDetail CourseDetailT { get; set; } = new CourseDetail();

        public CourseDetailView CourseDetail { get; set; } = new CourseDetailView();

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected async Task CreateCourseDetail()
        {
            Mapper.Map(CourseDetail, CourseDetailT);

            var courseDetail = await CourseDetailService.AddEntity(CourseDetailT);

            if (courseDetail != null)
            {
                NavigationManager.NavigateTo("/listCourseDetails");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listCourseDetails");
        }
    }
}
