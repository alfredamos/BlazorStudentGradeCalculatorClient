using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Mappings
{
    public class Mapps : Profile
    {
        public Mapps()
        {
            CreateMap<CourseDetail, CourseDetailView>().ReverseMap();
            CreateMap<Examm, ExammView>().ReverseMap();
            CreateMap<HomeWork, HomeWorkView>().ReverseMap();
            CreateMap<MidTerm, MidTermView>().ReverseMap();            
            CreateMap<HWScore, HWScoreView>().ReverseMap();
            CreateMap<OverallGrade, OverallGradeView>().ReverseMap();
            CreateMap<Student, StudentView>().ReverseMap();
        }
    }
}
