using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.Shared;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Pages.CourseDetails
{
    public class DeleteCourseCreditBase : ComponentBase
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

        protected ConfirmDelete DeleteConfirmation { get; set; }

        protected async override Task OnInitializedAsync()
        {
            CourseDetailT = await CourseDetailService.GetById(Convert.ToInt32(Id));

            Mapper.Map(CourseDetailT, CourseDetail);
        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }


        protected async Task DeleteCourseDetail(bool deleteConfirmed)
        {
            Mapper.Map(CourseDetail, CourseDetailT);

           if (deleteConfirmed)
            {
                await CourseDetailService.DeleteEntity(Id);
            }

            NavigationManager.NavigateTo("/listCourseDetails");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listCourseDetails");
        }
    }
}
