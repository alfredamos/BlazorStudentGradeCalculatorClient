using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.ViewModels
{
    public class HWScoreView
    {
        public int HWScoreID { get; set; }   
        [Required]
        public string SubjectName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        public double SubjectScore { get; set; }
        public string SubjectScoreInLetter { get; set; }

        public int? HomeWorkID { get; set; }
        public HomeWorkView HomeWork { get; set; }

    }
}
