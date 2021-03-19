using AutoMapper;
using BlazorStudentGradeCalculatorClient.Client.Contracts;
using BlazorStudentGradeCalculatorClient.Client.ViewModels;
using BlazorStudentGradeCalculatorClient.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStudentGradeCalculatorClient.Client.Pages.Examms
{
    public class AddExammsBase : ComponentBase
    {
        [Inject]
        public IExammService ExammService { get; set; }

        [Inject]
        public IUtility Utility { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public Examm ExammT { get; set; } = new Examm();

        public ExammView Examm { get; set; } = new ExammView();

        public List<Examm> ExammsT { get; set; } = new List<Examm>();

        public List<ExammView> Examms { get; set; } = new List<ExammView>();

        public bool ShowComponent { get; set; } = true;

        public bool ShowMainForm { get; set; } = true;

        public bool HideButtons { get; set; } = false;

        public string SchoolID { get; set; }

        public string StudentName { get; set; }

        public int NumbOfSujects { get; set; }

        public int Kounter { get; set; } = 1;

        public int NumbTemp { get; set; } 

        protected override void OnInitialized()
        {
            Utility.OnChange += StateHasChanged;

            Utility.ClearList(Examms);
        }

        protected async Task CreateExamms()
        {           
            Examms = ListOfExamms(Examm);

            Mapper.Map(Examms, ExammsT);

            await ExammService.AddEntities(ExammsT);

            Utility.ClearList(Examms);

            NavigationManager.NavigateTo("/listExamms");
        }

        protected List<ExammView> ListOfExamms(ExammView examm)
        {           
            Examm.SubjectScoreInLetter = Utility.GradeFetcher(examm.SubjectScore);            
            return Utility.ExammList(examm);
            
        }

        protected void Proceed()
        {                        
            ShowMainForm = false;
            
            Examms = ListOfExamms(Examm);

            Examm = new ExammView();
          
            if (Kounter <= NumbTemp)
            {             
                if (Kounter == NumbTemp) HideButtons = true;
                
                NavigationManager.NavigateTo("/addExamms");
                
            }            
            ++Kounter;
        }
       
        protected void Back()
        {            
            ShowComponent = true;
            HideButtons = true;
           
        }

        protected void Cancel()
        {
            NavigationManager.NavigateTo("/listExamms");
        }

    }
}
