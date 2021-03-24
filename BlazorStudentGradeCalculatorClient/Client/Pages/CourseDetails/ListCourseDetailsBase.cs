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
    public class ListCourseDetailsBase : ComponentBase
    {
        [Inject]
        public ICourseDetailService CourseDetailService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<CourseDetail> CourseDetailsT { get; set; } = new List<CourseDetail>();

        public List<CourseDetailView> CourseDetails { get; set; } = new List<CourseDetailView>();

        protected async override Task OnInitializedAsync()
        {
            CourseDetailsT = (await CourseDetailService.GetAll()).ToList();

            Mapper.Map(CourseDetailsT, CourseDetails);
        }
       
        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listCourseDetails");
        }
    }
}
