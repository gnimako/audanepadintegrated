using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_ProcurementProcessStepsWindowVM
    {
        public string WPProcurement_IdWindowVM { get; set; }
        public int  Employee_IdWindowVM { get; set; }
        public int  WPStepType_IdWindowVM { get; set; }
        public DateTime WPPlannedWindowVM { get; set; }
        
    }
}