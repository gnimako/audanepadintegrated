using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class ProcurementStepListViewModel
    {
        public string Transaction_IdVM { get; set; }
        public int StepNumberVM { get; set; }

        public string StepNameVM { get; set; }

        public string StepActionDescriptionVM { get; set; }

        public string StepPlannedDateVM { get; set; }

        public string StepStatusVM { get; set; }
        
    }
}