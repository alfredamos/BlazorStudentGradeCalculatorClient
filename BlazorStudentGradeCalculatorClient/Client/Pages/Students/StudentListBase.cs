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
    public class StudentListBase : ComponentBase
    {
        [Inject]
        public IStudentService StudentService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public List<Student> StudentsDB { get; set; } = new List<Student>();

        public List<StudentView> Students { get; set; } = new List<StudentView>();

        public StudentView StudentTemp { get; set; } = new StudentView();

        protected async override Task OnInitializedAsync()
        {
            StudentsDB = (await StudentService.GetAll()).ToList();

            Mapper.Map(StudentsDB, Students);
        }
    }
}
