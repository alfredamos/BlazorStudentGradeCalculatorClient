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
        public ICourseCreditService CourseCreditService { get; set; }

        [Inject]
        public ICourseDetailService CourseDetailService { get; set; }

        [Inject]
        public IStudentService StudentService { get; set; }

        [Inject]
        public IOverallGradeService OverallGradeService { get; set; }

        [Inject]
        public IExammService ExammService { get; set; }

        [Inject]
        public IHomeWorkService HomeWorkService { get; set; }

        [Inject]
        public IMidTermService MidTermService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public IHWUtility Utility { get; set; }

        public List<OverallGrade> OverallGradesDB { get; set; } = new List<OverallGrade>();

        public List<OverallGradeView> OverallGrades { get; set; } = new List<OverallGradeView>();

        public List<ExammView> Examms { get; set; } = new List<ExammView>();

        public List<Examm> ExammsDB { get; set; } = new List<Examm>();

        public HomeWork HomeWorkT { get; set; } = new HomeWork();

        public HomeWorkView HomeWork { get; set; } = new HomeWorkView();

        public List<HomeWork> HomeWorksDB { get; set; } = new List<HomeWork>();

        public List<HomeWorkView> HomeWorks { get; set; } = new List<HomeWorkView>();

        public List<MidTerm> MidTermsDB { get; set; } = new List<MidTerm>();

        public List<MidTermView> MidTerms { get; set; } = new List<MidTermView>();

        public Student StudentDB { get; set; } = new Student();

        public StudentView Student { get; set; } = new StudentView();

        public List<Student> StudentsDB { get; set; } = new List<Student>();

        public List<StudentView> Students { get; set; } = new List<StudentView>();

        public OverallGrade OverallGradeDB { get; set; } = new OverallGrade();

        public OverallGradeView OverallGrade { get; set; } = new OverallGradeView();


        protected async Task CreateStudentGrade()
        {
            await StudentOverallGrade();

            Mapper.Map(Student, StudentDB);

            StudentsDB.Add(StudentDB);

            await StudentService.UpdateEntities(StudentsDB);            

            NavigationManager.NavigateTo("/studentList");
        
            StudentsDB.Clear();
        }

        private async Task StudentOverallGrade()
        {
            var SchoolIdNumber = Student.SchoolIdNumber;
            ExammsDB = (await ExammService.Search(SchoolIdNumber)).ToList();
            MidTermsDB = (await MidTermService.Search(SchoolIdNumber)).ToList();
            HomeWorksDB = (await HomeWorkService.Search(SchoolIdNumber)).ToList();
            OverallGradesDB = (await OverallGradeService.Search(SchoolIdNumber)).ToList();

            Mapper.Map(ExammsDB, Examms);
            Mapper.Map(HomeWorksDB, HomeWorks);
            Mapper.Map(MidTermsDB, MidTerms);
            Mapper.Map(OverallGradesDB, OverallGrades);

            OverallGradeDB = await OverallGradeService.LookUp(SchoolIdNumber);

            Mapper.Map(OverallGradeDB, OverallGrade);

            Student.SchoolIdNumber = OverallGrade.SchoolIdNumber;
            Student.StudentName = OverallGrade.StudentName;
            Student.NumberOfSubjects = OverallGrade.NumberOfSubjects;
            Student.GPA = await CalculateGPA();

            Student.Examms = Examms;
            Student.MidTerms = MidTerms;
            Student.HomeWorks = HomeWorks;
            Student.OverallGrades = OverallGrades;

        }
        protected void Cancel()
        {
            NavigationManager.NavigateTo("/studentList");
        }

        private async Task<double> CalculateGPA()
        {
            var SumOfWeightOfScoresByCredit = 0.0;
            var sumOfCredits = 0.0;
            var CumulativeGPA = 0.0;
            foreach (var item in OverallGradesDB)
            {
                var SubjectName = item.SubjectName;
                var gradeLetter = item.SubjectScoreInLetter;
                var courseDetail = await CourseDetailService.LookUp(SubjectName);
                var weightOfCourse = courseDetail.SubjectWeight;
                var SubjectScore = item.SubjectScore;
                var courseCredit = await CourseCreditService.LookUp(gradeLetter);
                var credit = courseCredit.GradeCredit;

                SumOfWeightOfScoresByCredit += weightOfCourse * credit;
                sumOfCredits += credit;
            }
            if (sumOfCredits != 0)
                    CumulativeGPA = SumOfWeightOfScoresByCredit / sumOfCredits;

            return CumulativeGPA;
        }
    }
}
