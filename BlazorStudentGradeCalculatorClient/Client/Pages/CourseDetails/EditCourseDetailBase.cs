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
    public class EditCourseDetailBase : ComponentBase
    {
        [Inject]
        public ICourseDetailService CourseDetailService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Parameter]
        public int Id { get; set; }

        public CourseDetail CourseDetailT { get; set; } = new CourseDetail();

        public CourseDetailView CourseDetail { get; set; } = new CourseDetailView();

        protected async override Task OnInitializedAsync()
        {
            CourseDetailT = await CourseDetailService.GetById(Convert.ToInt32(Id));

            Mapper.Map(CourseDetailT, CourseDetail);
        }

        protected async Task UpdateCourseDetail()
        {
            Mapper.Map(CourseDetail, CourseDetailT);

            var courseDetail = await CourseDetailService.UpdateEntity(CourseDetailT);

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
