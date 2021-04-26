using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NodaTime;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AUDANEPAD_Integrated.ViewModels
{
    public class WP_ProcurementProcessStepsTestVM
    {
        public string Transaction_IdVM { get; set; }
        public DateTime WPPlannedDateVM { get; set; }
        
    }
}