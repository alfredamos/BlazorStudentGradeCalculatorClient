using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Pages.Students
{
    public class AddStudentBase : ComponentBase
    {
        [Inject]
        public IStudentService StudentService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public Student StudentT { get; set; } = new Student();

        public StudentView Student { get; set; } = new StudentView();

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected async Task CreateStudent()
        {
            Mapper.Map(Student, StudentT);

            var student = await StudentService.AddEntity(StudentT);

            if (student != null)
            {                
                NavigationManager.NavigateTo("/studentList");
            }
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/studentList");
        }
    }
}
