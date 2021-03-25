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

namespace BlazorStudentGradeCalculatorClient.Client.Pages.CourseCredits
{
    public class DeleteCourseCreditBase : ComponentBase
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

        protected ConfirmDelete DeleteConfirmation { get; set; }

        protected async override Task OnInitializedAsync()
        {
            CourseCreditDB = await CourseCreditService.GetById(Convert.ToInt32(Id));

            Mapper.Map(CourseCreditDB, CourseCredit);
        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }


        protected async Task DeleteCourseCredit(bool deleteConfirmed)
        {
            Mapper.Map(CourseCredit, CourseCreditDB);

           if (deleteConfirmed)
            {
                await CourseCreditService.DeleteEntity(Id);
            }

            NavigationManager.NavigateTo("/listCourseCredits");
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listCourseCredits");
        }
    }
}
