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
            CreateMap<Examm, ExammView>().ReverseMap();
            CreateMap<HomeWork, HomeWorkView>().ReverseMap();
            CreateMap<MidTerm, MidTermView>().ReverseMap();
            CreateMap<Score, ScoreView>().ReverseMap();
            CreateMap<HWScore, HWScoreView>().ReverseMap();
            CreateMap<Score, HWScore>().ReverseMap();
            CreateMap<ScoreView, HWScoreView>().ReverseMap();
            CreateMap<Student, StudentView>().ReverseMap();
        }
    }
}
