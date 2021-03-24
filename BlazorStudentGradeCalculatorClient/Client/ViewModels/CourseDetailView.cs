using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class CourseDetailView
    {
        public int CourseDetailID { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public int SubjectWeight { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
