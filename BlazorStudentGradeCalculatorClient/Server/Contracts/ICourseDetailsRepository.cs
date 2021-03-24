﻿using BlazorStudentGradeCalculatorClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Server.Contracts
{
    public interface ICourseDetailsRepository : IBaseRepository<CourseDetail>
    {
        Task<CourseDetail> LookUp(string searchKey);
    }
}
