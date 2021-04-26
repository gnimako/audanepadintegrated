using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_ProcurementProcessStepsVM
    {
        public string Transaction_IdVM { get; set; }
        public string WPMainRecord_idVM { get; set; }
        public string WPProcurement_IdVM { get; set; }

        public int  Employee_IdVM { get; set; }
        public int  WPStepNumberVM { get; set; }
        public string  WPStepNumberLabelVM { get; set; }
        public int  WPStepType_IdVM { get; set; }
        public string  ProcurementProcessStepAction { get; set; }

        
        
        public DateTime WPPlannedDateVM { get; set; }
        public DateTime WPActualDateVM { get; set; }

        public string WPStep_StatusVM { get; set; }

        // [UIHint("ClientProcurementProcessStep")]
        // public CategoryViewModel ProcurementProcessStep { get; set; }

        // [UIHint("ClientProcurementDate")]
        // public CategoryDateViewModel ProcurementPlannedDate { get; set; }
        
        
        
    }
}