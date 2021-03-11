using AutoMapper;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Server.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Examm, Examm>();
            CreateMap<HomeWork, HomeWork>();
            CreateMap<MidTerm, MidTerm>();
            CreateMap<Student, Student>();
            CreateMap<HWScore, HWScore>();
        }
    }
}
